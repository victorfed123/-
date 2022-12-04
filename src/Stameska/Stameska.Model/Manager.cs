using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KompasAPI7;
using Kompas6API5;
using Kompas6Constants3D;
using Kompas6Constants;

namespace Stameska.Model
{
    /// <summary>
    /// класс Менеджера
    /// </summary>
    public class Manager
    {
        //Длина для фаски 1
        private double katet1;
        //длина для фаски 2
        private double katet2;
        //координаты для указания ребра
        private double x;
        private double y;
        private double z;
        //радиус скругления
        private double r;

        /// <summary>
        /// выделение памяти под объект компас коннектора
        /// </summary>
        public KompasConnector _kompasApp = new KompasConnector();

        /// <summary>
        /// Конструктор с вложенным классом
        /// </summary>
        /// <param name="kompasApp"></param>
        public Manager(KompasConnector kompasApp)
        {
            if (kompasApp == null)
            {
                return;
            }
            _kompasApp = kompasApp;
        }

        /// <summary>
        /// Создание скругления
        /// </summary>
        /// <param name="Chisel"></param>
        /// <param name="r"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        private void MakeFillet(ksPart Chisel, double r, double x, double y, double z)
        {
            ksEntity iFillet = (ksEntity)Chisel.NewEntity((short)Obj3dType.o3d_fillet);
            if (iFillet != null)
            {
                ksFilletDefinition filletDefenition = (ksFilletDefinition)iFillet.GetDefinition();
                if (filletDefenition != null)
                {
                    filletDefenition.radius = r;
                    filletDefenition.tangent = true;
                    var araa = filletDefenition.array();
                    EntityCollection iCollection = Chisel.EntityCollection((short)Obj3dType.o3d_edge);
                    iCollection.SelectByPoint(x, y, z);
                    araa.Add(iCollection.Last());
                    iFillet.Create();
                }
            }
        }

        /// <summary>
        /// Создание фасок
        /// </summary>
        /// <param name="Chisel"></param>
        /// <param name="katet1"></param>
        /// <param name="katet2"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        private void MakeChamfer(ksPart Chisel, double katet1,
            double katet2, double x, double y, double z)
        {
            /// Создание боковых фасок
            ksEntity iChamferSide = (ksEntity)Chisel.NewEntity((short)Obj3dType.o3d_chamfer);
            if (iChamferSide != null)
            {
                ksChamferDefinition chamferDefinitionS = (ksChamferDefinition)iChamferSide.GetDefinition();
                if (chamferDefinitionS != null)
                {
                    chamferDefinitionS.tangent = true;

                    chamferDefinitionS.SetChamferParam(true, katet1, katet2);
                    var ar = chamferDefinitionS.array();
                    EntityCollection iCollection = Chisel.EntityCollection((short)Obj3dType.o3d_edge);
                    iCollection.SelectByPoint(x, y, z);
                    ar.Add(iCollection.Last());
                    iChamferSide.Create();
                }
            }
        }

        /// <summary>
        /// Создание кольца
        /// </summary>
        /// <param name="chiselData"></param>
        /// <param name="Chisel"></param>
        /// <param name="planeXOY"></param>
        private void BuildRing(ChiselData chiselData, ksPart Chisel, ksEntity planeXOY)
        {
            // получим интерфейс базовой плоскости XOY
            ksEntity ringSketch = (ksEntity)Chisel.NewEntity((short)Obj3dType.o3d_sketch);
            if (ringSketch != null)
            {
                // интерфейс свойств эскиза
                ksSketchDefinition iDefinitionSketch = (ksSketchDefinition)ringSketch.GetDefinition();
                if (iDefinitionSketch != null)
                {
                    iDefinitionSketch.SetPlane(planeXOY);
                    ringSketch.Create();

                    ksDocument2D Ring = (ksDocument2D)iDefinitionSketch.BeginEdit();

                    Ring.ksCircle(0, 0, chiselData.RingD / 2, 1);

                    iDefinitionSketch.EndEdit();

                    ksEntity entityExtr = (ksEntity)Chisel.NewEntity((short)Obj3dType.o3d_bossExtrusion);
                    if (entityExtr != null)
                    {
                        // интерфейс свойств базовой операции выдавливания
                        ksBossExtrusionDefinition extrusionDef = (ksBossExtrusionDefinition)entityExtr.GetDefinition();
                        if (extrusionDef != null)
                        {
                            // интерфейс структуры параметров выдавливания
                            ksExtrusionParam extrProp = (ksExtrusionParam)extrusionDef.ExtrusionParam();
                            // интерфейс структуры параметров тонкой стенки
                            ksThinParam thinProp = (ksThinParam)extrusionDef.ThinParam();
                            if (extrProp != null && thinProp != null)
                            {
                                // эскиз операции выдавливания
                                extrusionDef.SetSketch(ringSketch);
                                // направление выдавливания (прямое)
                                extrProp.direction = (short)Direction_Type.dtNormal;
                                // тип выдавливания (строго на глубину)
                                extrProp.typeNormal = (short)End_Type.etBlind;
                                // глубина выдавливания
                                extrProp.depthNormal = chiselData.BladeL / 50; 
                                thinProp.thin = false; // без тонкой стенки
                                entityExtr.Create(); // создадим операцию
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Создание рукояти
        /// </summary>
        /// <param name="chiselData"></param>
        /// <param name="Chisel"></param>
        /// <param name="planeXOY"></param>
        private void BuildHandle(ChiselData chiselData, ksPart Chisel, ksEntity planeXOY)
        {
            /// Создание рукояти
            // создадим новый эскиз
            ksEntity handleSketch = (ksEntity)Chisel.NewEntity((short)Obj3dType.o3d_sketch);
            if (handleSketch != null)
            {
                // интерфейс свойств эскиза
                ksSketchDefinition HandleSketchDef = (ksSketchDefinition)handleSketch.GetDefinition();
                if (HandleSketchDef != null)
                {
                    HandleSketchDef.SetPlane(planeXOY); // установим плоскость
                    handleSketch.Create(); // создадим эскиз

                    // интерфейс редактора эскиза
                    ksDocument2D Handle = (ksDocument2D)HandleSketchDef.BeginEdit();
                    Handle.ksCircle(0, 0, chiselData.ChiselW / 2, 1);
                    HandleSketchDef.EndEdit(); // завершение редактирования эскиза

                    // приклеим выдавливанием
                    ksEntity entityBossExtr = (ksEntity)Chisel.NewEntity((short)Obj3dType.o3d_bossExtrusion);
                    if (entityBossExtr != null)
                    {
                        ksBossExtrusionDefinition bossExtrDef = (ksBossExtrusionDefinition)entityBossExtr.GetDefinition();
                        if (bossExtrDef != null)
                        {
                            ksExtrusionParam extrProp = (ksExtrusionParam)bossExtrDef.ExtrusionParam();
                            ksThinParam thinProp = (ksThinParam)bossExtrDef.ThinParam();
                            if (extrProp != null && thinProp != null)
                            {
                                bossExtrDef.SetSketch(handleSketch); 

                                extrProp.direction = (short)Direction_Type.dtReverse;
                                extrProp.typeNormal = (short)End_Type.etBlind;
                                extrProp.depthReverse = chiselData.HandleL;
                                thinProp.thin = false; 
                                entityBossExtr.Create(); 
                            }
                        }
                    }
                }
            }
            //Задаем параметры для скругления
            x = 0;
            y = chiselData.ChiselW / 2;
            z = -chiselData.HandleL;
            r = 10;
            MakeFillet(Chisel, r, x, y, z);
        }

        /// <summary>
        /// создание бруска
        /// </summary>
        /// <param name="chiselData"></param>
        /// <param name="Chisel"></param>
        private void BuildStraightBar(ChiselData chiselData, ksPart Chisel)
        {
            /// Создание бруска
            /// // создадим новый эскиз
            ksEntity barSketch = (ksEntity)Chisel.NewEntity((short)Obj3dType.o3d_sketch);
            ksEntity ksEntityPlaneOffsetBar = (ksEntity)Chisel.NewEntity((short)Obj3dType.o3d_planeOffset);

            ksEntity ksEntityPlaneXOY = (ksEntity)Chisel.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
            ksPlaneOffsetDefinition ksPlaneOffsetDefinitionBar = (ksPlaneOffsetDefinition)ksEntityPlaneOffsetBar.GetDefinition();
            ksPlaneOffsetDefinitionBar.SetPlane(ksEntityPlaneXOY);
            ksPlaneOffsetDefinitionBar.direction = true;
            ksPlaneOffsetDefinitionBar.offset = chiselData.BladeL / 50;
            ksEntityPlaneOffsetBar.Create();

            if (barSketch != null)
            {
                // интерфейс свойств эскиза
                ksSketchDefinition barSketchDef = (ksSketchDefinition)barSketch.GetDefinition();
                if (barSketchDef != null)
                {
                    barSketchDef.SetPlane(ksEntityPlaneOffsetBar); // установим плоскость
                    barSketch.Create(); // создадим эскиз

                    // интерфейс редактора эскиза
                    ksDocument2D bar = (ksDocument2D)barSketchDef.BeginEdit();

                    bar.ksLineSeg(-chiselData.BladeH / 2, -chiselData.BladeH / 2, -chiselData.BladeH / 2, chiselData.BladeH / 2, 1);
                    bar.ksLineSeg(-chiselData.BladeH / 2, chiselData.BladeH / 2, chiselData.BladeH / 2, chiselData.BladeH / 2, 1);
                    bar.ksLineSeg(chiselData.BladeH / 2, chiselData.BladeH / 2, chiselData.BladeH / 2, -chiselData.BladeH / 2, 1);
                    bar.ksLineSeg(chiselData.BladeH / 2, -chiselData.BladeH / 2, -chiselData.BladeH / 2, -chiselData.BladeH / 2, 1);
                    barSketchDef.EndEdit(); // завершение редактирования эскиза

                    // приклеим выдавливанием
                    ksEntity entityBossExtr = (ksEntity)Chisel.NewEntity((short)Obj3dType.o3d_bossExtrusion);
                    if (entityBossExtr != null)
                    {
                        ksBossExtrusionDefinition bossExtrDef = (ksBossExtrusionDefinition)entityBossExtr.GetDefinition();
                        if (bossExtrDef != null)
                        {
                            ksExtrusionParam
                            extrProp = (ksExtrusionParam)bossExtrDef.ExtrusionParam(); 
                            ksThinParam thinProp = (ksThinParam)bossExtrDef.ThinParam(); 
                            if (extrProp != null && thinProp != null)
                            {
                                bossExtrDef.SetSketch(barSketch); 

                                extrProp.direction = (short)Direction_Type.dtNormal;
                                extrProp.typeNormal = (short)End_Type.etBlind; 
                                extrProp.depthNormal = chiselData.BladeL / 10; 
                                thinProp.thin = false; 
                                entityBossExtr.Create();
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Создание прямого лезвия
        /// </summary>
        /// <param name="chiselData"></param>
        /// <param name="Chisel"></param>
        private void BuildStraightBlade(ChiselData chiselData, ksPart Chisel)
        {
            /// Создание лезвия
            /// создадим новый эскиз
            ksEntity bladeSketch = (ksEntity)Chisel.NewEntity((short)Obj3dType.o3d_sketch);
            ksEntity ksEntityPlaneOffsetBlade = (ksEntity)Chisel.NewEntity((short)Obj3dType.o3d_planeOffset);

            ksEntity ksEntityPlaneXOYBlade = (ksEntity)Chisel.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
            ksPlaneOffsetDefinition ksPlaneOffsetDefinitionBlade = (ksPlaneOffsetDefinition)ksEntityPlaneOffsetBlade.GetDefinition();
            ksPlaneOffsetDefinitionBlade.SetPlane(ksEntityPlaneXOYBlade);
            ksPlaneOffsetDefinitionBlade.direction = true;
            ksPlaneOffsetDefinitionBlade.offset = chiselData.BladeL * 3 / 25;
            ksEntityPlaneOffsetBlade.Create();

            if (bladeSketch != null)
            {
                // интерфейс свойств эскиза
                ksSketchDefinition bladeSketchDef = (ksSketchDefinition)bladeSketch.GetDefinition();
                if (bladeSketchDef != null)
                {
                    bladeSketchDef.SetPlane(ksEntityPlaneOffsetBlade); // установим плоскость
                    bladeSketch.Create(); // создадим эскиз

                    // интерфейс редактора эскиза
                    ksDocument2D blade = (ksDocument2D)bladeSketchDef.BeginEdit();

                    
                    blade.ksLineSeg(-chiselData.ChiselW / 2, -chiselData.BladeH / 2,
                        -chiselData.ChiselW / 2, chiselData.BladeH / 2, 1);
                    blade.ksLineSeg(-chiselData.ChiselW / 2, chiselData.BladeH / 2,
                        chiselData.ChiselW / 2, chiselData.BladeH / 2, 1);
                    blade.ksLineSeg(chiselData.ChiselW / 2, chiselData.BladeH / 2, 
                        chiselData.ChiselW / 2, -chiselData.BladeH / 2, 1);
                    blade.ksLineSeg(chiselData.ChiselW / 2, -chiselData.BladeH / 2,
                        -chiselData.ChiselW / 2, -chiselData.BladeH / 2, 1);
                    bladeSketchDef.EndEdit(); // завершение редактирования эскиза

                    // приклеим выдавливанием
                    ksEntity entityBossExtr = (ksEntity)Chisel.NewEntity((short)Obj3dType.o3d_bossExtrusion);
                    if (entityBossExtr != null)
                    {
                        ksBossExtrusionDefinition bossExtrDef = (ksBossExtrusionDefinition)entityBossExtr.GetDefinition();
                        if (bossExtrDef != null)
                        {
                            ksExtrusionParam extrProp = (ksExtrusionParam)bossExtrDef.ExtrusionParam();
                            ksThinParam thinProp = (ksThinParam)bossExtrDef.ThinParam(); 
                            if (extrProp != null && thinProp != null)
                            {
                                bossExtrDef.SetSketch(bladeSketch); 
                                extrProp.direction = (short)Direction_Type.dtNormal; 
                                extrProp.typeNormal = (short)End_Type.etBlind;
                                extrProp.depthNormal = chiselData.BladeL; 
                                thinProp.thin = false; 
                                entityBossExtr.Create(); 
                            }
                        }
                    }
                }
            }
            katet1 = chiselData.BladeH;
            katet2 = (chiselData.ChiselW - chiselData.BladeH) / 2;
            x = chiselData.ChiselW / 2;
            y = chiselData.BladeH / 2;
            z = chiselData.BladeL;
            MakeChamfer(Chisel, katet1, katet2, x, y, z);

            x = -chiselData.ChiselW / 2;
            MakeChamfer(Chisel, katet2, katet1, x, y, z);

            katet1 = chiselData.BladeH;
            katet2 = chiselData.BladeL / 5;
            x = 0;
            y = chiselData.BladeH / 2;
            z = (chiselData.BladeL) + (chiselData.BladeL / 50) + (chiselData.BladeL / 10);
            MakeChamfer(Chisel, katet1, katet2, x, y, z);
        }

        /// <summary>
        /// Создание бруска для уголковатого лезвия
        /// </summary>
        /// <param name="chiselData"></param>
        /// <param name="Chisel"></param>
        private void BuildCornerBar(ChiselData chiselData, ksPart Chisel)
        {
            /// Создание бруска
            /// // создадим новый эскиз
            ksEntity barSketch = (ksEntity)Chisel.NewEntity((short)Obj3dType.o3d_sketch);
            ksEntity ksEntityPlaneOffsetBar = (ksEntity)Chisel.NewEntity((short)Obj3dType.o3d_planeOffset);

            ksEntity ksEntityPlaneXOY = (ksEntity)Chisel.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
            ksPlaneOffsetDefinition ksPlaneOffsetDefinitionBar = (ksPlaneOffsetDefinition)ksEntityPlaneOffsetBar.GetDefinition();
            ksPlaneOffsetDefinitionBar.SetPlane(ksEntityPlaneXOY);
            ksPlaneOffsetDefinitionBar.direction = true;
            ksPlaneOffsetDefinitionBar.offset = chiselData.BladeL / 50;
            ksEntityPlaneOffsetBar.Create();

            if (barSketch != null)
            {
                // интерфейс свойств эскиза
                ksSketchDefinition barSketchDef = (ksSketchDefinition)barSketch.GetDefinition();
                if (barSketchDef != null)
                {
                    barSketchDef.SetPlane(ksEntityPlaneOffsetBar); // установим плоскость
                    barSketch.Create(); // создадим эскиз

                    // интерфейс редактора эскиза
                    ksDocument2D bar = (ksDocument2D)barSketchDef.BeginEdit();

                    bar.ksLineSeg(-chiselData.BladeH / 2, chiselData.BladeH / 4, chiselData.BladeH / 2, chiselData.BladeH / 4, 1);
                    bar.ksArcByPoint(0, chiselData.BladeH / 4, chiselData.BladeH / 2,
    -chiselData.BladeH, chiselData.BladeH / 4, chiselData.BladeH, chiselData.BladeH / 4, 1, 1);
                    barSketchDef.EndEdit(); // завершение редактирования эскиза

                    // приклеим выдавливанием
                    ksEntity entityBossExtr = (ksEntity)Chisel.NewEntity((short)Obj3dType.o3d_bossExtrusion);
                    if (entityBossExtr != null)
                    {
                        ksBossExtrusionDefinition bossExtrDef = (ksBossExtrusionDefinition)entityBossExtr.GetDefinition();
                        if (bossExtrDef != null)
                        {
                            ksExtrusionParam
                            extrProp = (ksExtrusionParam)bossExtrDef.ExtrusionParam(); 
                            ksThinParam thinProp = (ksThinParam)bossExtrDef.ThinParam(); 
                            if (extrProp != null && thinProp != null)
                            {
                                bossExtrDef.SetSketch(barSketch); 

                                extrProp.direction = (short)Direction_Type.dtNormal;
                                extrProp.typeNormal = (short)End_Type.etBlind; 
                                extrProp.depthNormal = chiselData.BladeL / 10;
                                thinProp.thin = false; 
                                entityBossExtr.Create(); 
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Создание уголковатого лезвия
        /// </summary>
        /// <param name="chiselData"></param>
        /// <param name="Chisel"></param>
        private void BuildCornerBlade(ChiselData chiselData, ksPart Chisel)
        {
            /// Создание лезвия
            /// создадим новый эскиз
            ksEntity bladeSketch = (ksEntity)Chisel.NewEntity((short)Obj3dType.o3d_sketch);
            ksEntity ksEntityPlaneOffsetBlade = (ksEntity)Chisel.NewEntity((short)Obj3dType.o3d_planeOffset);

            ksEntity ksEntityPlaneXOYBlade = (ksEntity)Chisel.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
            ksPlaneOffsetDefinition ksPlaneOffsetDefinitionBlade = (ksPlaneOffsetDefinition)ksEntityPlaneOffsetBlade.GetDefinition();
            ksPlaneOffsetDefinitionBlade.SetPlane(ksEntityPlaneXOYBlade);
            ksPlaneOffsetDefinitionBlade.direction = true;
            ksPlaneOffsetDefinitionBlade.offset = chiselData.BladeL * 3 / 25;
            ksEntityPlaneOffsetBlade.Create();

            if (bladeSketch != null)
            {
                // интерфейс свойств эскиза
                ksSketchDefinition bladeSketchDef = (ksSketchDefinition)bladeSketch.GetDefinition();
                if (bladeSketchDef != null)
                {
                    bladeSketchDef.SetPlane(ksEntityPlaneOffsetBlade); // установим плоскость
                    bladeSketch.Create(); // создадим эскиз

                    // интерфейс редактора эскиза
                    ksDocument2D blade = (ksDocument2D)bladeSketchDef.BeginEdit();

                    blade.ksLineSeg(-chiselData.BladeH / 2, chiselData.BladeH / 4, 
                        (-chiselData.BladeH / 2) + (chiselData.BladeH/10), chiselData.BladeH / 4, 1);
                    blade.ksLineSeg(chiselData.BladeH / 2, chiselData.BladeH / 4,
                        (chiselData.BladeH / 2) -(chiselData.BladeH/10), chiselData.BladeH / 4, 1);
                    blade.ksArcByPoint(0, chiselData.BladeH/4, chiselData.BladeH / 2,
                        -chiselData.BladeH, chiselData.BladeH / 4, chiselData.BladeH, chiselData.BladeH / 4, 1, 1);
                    blade.ksArcByPoint(0, chiselData.BladeH / 4, (chiselData.BladeH / 2) - (chiselData.BladeH/10), -chiselData.BladeH + (chiselData.BladeH/10),
                        chiselData.BladeH / 4, chiselData.BladeH - (chiselData.BladeH/10), chiselData.BladeH / 4, 1, 1);

                    bladeSketchDef.EndEdit(); // завершение редактирования эскиза

                    // приклеим выдавливанием
                    ksEntity entityBossExtr = (ksEntity)Chisel.NewEntity((short)Obj3dType.o3d_bossExtrusion);
                    if (entityBossExtr != null)
                    {
                        ksBossExtrusionDefinition bossExtrDef = (ksBossExtrusionDefinition)entityBossExtr.GetDefinition();
                        if (bossExtrDef != null)
                        {
                            // интерфейс структуры параметров выдавливания
                            ksExtrusionParam extrProp = (ksExtrusionParam)bossExtrDef.ExtrusionParam();
                            // интерфейс структуры параметров тонкой стенки
                            ksThinParam thinProp = (ksThinParam)bossExtrDef.ThinParam();
                            if (extrProp != null && thinProp != null)
                            {
                                bossExtrDef.SetSketch(bladeSketch);
                                extrProp.direction = (short)Direction_Type.dtNormal; 
                                extrProp.typeNormal = (short)End_Type.etBlind; 
                                extrProp.depthNormal = chiselData.BladeL; 
                                thinProp.thin = false; 
                                entityBossExtr.Create();           
                            }
                        }
                    }
                }
            }
            r = 1;
            katet1 = (chiselData.BladeH / 2) - (chiselData.BladeH / 10);
            katet2 = 5;
            x = 0;
            y = chiselData.BladeH / 4;
            z = (chiselData.BladeL / 50) + (chiselData.BladeL / 10);
            MakeChamfer(Chisel, katet1, katet2, x, y, z);

            katet1 = chiselData.BladeH / 10;
            katet2 = chiselData.BladeL/20;
            y = (-chiselData.BladeH / 4) + (chiselData.BladeH/10);
            z = chiselData.BladeL + (chiselData.BladeL / 50) + (chiselData.BladeL / 10);
            MakeChamfer(Chisel, katet1, katet2, x, y, z);
        }

        /// <summary>
        /// Создания детали с прямым лезвием
        /// </summary>
        /// <param name="chiselData"></param>
        public void BuildModel(ChiselData chiselData)
        {
            var Chisel = _kompasApp.Chisel;
            // 1-интерфейс на плоскость XOY
            ksEntity planeXOY = (ksEntity)Chisel.GetDefaultEntity((short)Obj3dType.o3d_planeXOY); // 1-интерфейс на плоскость XOY

            BuildRing(chiselData, Chisel, planeXOY);
            BuildHandle(chiselData, Chisel, planeXOY);
            BuildStraightBar(chiselData, Chisel);
            BuildStraightBlade(chiselData, Chisel);
        }

        /// <summary>
        /// Создание модели с уголковатым лезвием
        /// </summary>
        /// <param name="chiselData"></param>
        public void BuildCornerModel(ChiselData chiselData)
        {
            var Chisel = _kompasApp.Chisel;
            // 1-интерфейс на плоскость XOY
            ksEntity planeXOY = (ksEntity)Chisel.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);

            BuildRing(chiselData, Chisel, planeXOY);
            BuildHandle(chiselData, Chisel, planeXOY);
            BuildCornerBar(chiselData, Chisel);
            BuildCornerBlade(chiselData, Chisel);
        }
    }
}


