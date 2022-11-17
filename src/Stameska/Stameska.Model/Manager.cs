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
        /// метод создания детали
        /// </summary>
        /// <param name="chiselData"></param>
        public void BuildModel(ChiselData chiselData)
        {

            var Chisel = _kompasApp.Chisel;
            // получим интерфейс базовой плоскости XOY
            ksEntity planeXOY = (ksEntity)Chisel.GetDefaultEntity((short)Obj3dType.o3d_planeXOY); // 1-интерфейс на плоскость XOY
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

                    Ring.ksCircle(0, 0, chiselData.RingD/2,1);

                    iDefinitionSketch.EndEdit();

                    ksEntity entityExtr = (ksEntity)Chisel.NewEntity((short)Obj3dType.o3d_bossExtrusion);
                    if (entityExtr != null)
                    {
                        // интерфейс свойств базовой операции выдавливания
                        ksBossExtrusionDefinition extrusionDef = (ksBossExtrusionDefinition)entityExtr.GetDefinition(); // интерфейс базовой операции выдавливания
                        if (extrusionDef != null)
                        {
                            ksExtrusionParam extrProp = (ksExtrusionParam)extrusionDef.ExtrusionParam(); // интерфейс структуры параметров выдавливания
                            ksThinParam thinProp = (ksThinParam)extrusionDef.ThinParam(); // интерфейс структуры параметров тонкой стенки
                            if (extrProp != null && thinProp != null)
                            {
                                extrusionDef.SetSketch(ringSketch); // эскиз операции выдавливания

                                extrProp.direction = (short)Direction_Type.dtNormal; // направление выдавливания (прямое)
                                extrProp.typeNormal = (short)End_Type.etBlind; // тип выдавливания (строго на глубину)
                                extrProp.depthNormal = chiselData.BladeL/50; // глубина выдавливания
                                thinProp.thin = false; // без тонкой стенки
                                entityExtr.Create(); // создадим операцию
                            }
                        }
                    }
                }
            }
            /// Создание рукояти
            // создадим новый эскиз
            ksEntity hangleSketch = (ksEntity)Chisel.NewEntity((short)Obj3dType.o3d_sketch);
                if (hangleSketch != null)
                {
                    // интерфейс свойств эскиза
                    ksSketchDefinition hangleSketchDef = (ksSketchDefinition)hangleSketch.GetDefinition();
                    if (hangleSketchDef != null)
                    {
                        hangleSketchDef.SetPlane(planeXOY); // установим плоскость
                        hangleSketch.Create(); // создадим эскиз

                        // интерфейс редактора эскиза
                        ksDocument2D hangle = (ksDocument2D)hangleSketchDef.BeginEdit();
                        hangle.ksCircle(0, 0, chiselData.ChiselW/2,1);
                        hangleSketchDef.EndEdit(); // завершение редактирования эскиза

                        // приклеим выдавливанием
                        ksEntity entityBossExtr = (ksEntity)Chisel.NewEntity((short)Obj3dType.o3d_bossExtrusion);
                        if (entityBossExtr != null)
                        {
                            ksBossExtrusionDefinition bossExtrDef = (ksBossExtrusionDefinition)entityBossExtr.GetDefinition();
                            if (bossExtrDef != null)
                            {
                                ksExtrusionParam
                                extrProp = (ksExtrusionParam)bossExtrDef.ExtrusionParam(); // интерфейс структуры параметров выдавливания
                                ksThinParam thinProp = (ksThinParam)bossExtrDef.ThinParam(); // интерфейс структуры параметров тонкой стенки
                                if (extrProp != null && thinProp != null)
                                {
                                    bossExtrDef.SetSketch(hangleSketch); // эскиз операции выдавливания

                                    extrProp.direction = (short)Direction_Type.dtReverse; // направление выдавливания (обратное)
                                    extrProp.typeNormal = (short)End_Type.etBlind; // тип выдавливания (строго на глубину)
                                    extrProp.depthReverse = chiselData.HangleL; // глубина выдавливания
                                    thinProp.thin = false; // без тонкой стенки
                                    entityBossExtr.Create(); // создадим операцию
                                }
                            }
                        }
                    }
                }

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

                    bar.ksLineSeg(-chiselData.BladeH/2, -chiselData.BladeH/2, -chiselData.BladeH/2, chiselData.BladeH/2, 1);
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
                            extrProp = (ksExtrusionParam)bossExtrDef.ExtrusionParam(); // интерфейс структуры параметров выдавливания
                            ksThinParam thinProp = (ksThinParam)bossExtrDef.ThinParam(); // интерфейс структуры параметров тонкой стенки
                            if (extrProp != null && thinProp != null)
                            {
                                bossExtrDef.SetSketch(barSketch); // эскиз операции выдавливания

                                extrProp.direction = (short)Direction_Type.dtNormal; // направление выдавливания (обратное)
                                extrProp.typeNormal = (short)End_Type.etBlind; // тип выдавливания (строго на глубину)
                                extrProp.depthNormal = chiselData.BladeL/10; // глубина выдавливания
                                thinProp.thin = false; // без тонкой стенки
                                entityBossExtr.Create(); // создадим операцию
                            }
                        }
                    }
                }
            }
            /// Создание лезвия
            /// // создадим новый эскиз
            ksEntity bladeSketch = (ksEntity)Chisel.NewEntity((short)Obj3dType.o3d_sketch);
            ksEntity ksEntityPlaneOffsetBlade = (ksEntity)Chisel.NewEntity((short)Obj3dType.o3d_planeOffset);

            ksEntity ksEntityPlaneXOYBlade = (ksEntity)Chisel.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
            ksPlaneOffsetDefinition ksPlaneOffsetDefinitionBlade = (ksPlaneOffsetDefinition)ksEntityPlaneOffsetBlade.GetDefinition();
            ksPlaneOffsetDefinitionBlade.SetPlane(ksEntityPlaneXOYBlade);
            ksPlaneOffsetDefinitionBlade.direction = true;
            ksPlaneOffsetDefinitionBlade.offset = chiselData.BladeL *3 / 25 ;
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

                    blade.ksLineSeg(-chiselData.ChiselW/2, -chiselData.BladeH / 2, -chiselData.ChiselW/2, chiselData.BladeH / 2, 1);
                    blade.ksLineSeg(-chiselData.ChiselW/2, chiselData.BladeH / 2, chiselData.ChiselW/2, chiselData.BladeH / 2, 1);
                    blade.ksLineSeg(chiselData.ChiselW/2, chiselData.BladeH / 2, chiselData.ChiselW/2, -chiselData.BladeH / 2, 1);
                    blade.ksLineSeg(chiselData.ChiselW/2, -chiselData.BladeH / 2, -chiselData.ChiselW/2, -chiselData.BladeH / 2, 1);
                    bladeSketchDef.EndEdit(); // завершение редактирования эскиза

                    // приклеим выдавливанием
                    ksEntity entityBossExtr = (ksEntity)Chisel.NewEntity((short)Obj3dType.o3d_bossExtrusion);
                    if (entityBossExtr != null)
                    {
                        ksBossExtrusionDefinition bossExtrDef = (ksBossExtrusionDefinition)entityBossExtr.GetDefinition();
                        if (bossExtrDef != null)
                        {
                            ksExtrusionParam
                            extrProp = (ksExtrusionParam)bossExtrDef.ExtrusionParam(); // интерфейс структуры параметров выдавливания
                            ksThinParam thinProp = (ksThinParam)bossExtrDef.ThinParam(); // интерфейс структуры параметров тонкой стенки
                            if (extrProp != null && thinProp != null)
                            {
                                bossExtrDef.SetSketch(bladeSketch); // эскиз операции выдавливания
                                extrProp.direction = (short)Direction_Type.dtNormal; // направление выдавливания (обратное)
                                extrProp.typeNormal = (short)End_Type.etBlind; // тип выдавливания (строго на глубину)
                                extrProp.depthNormal = chiselData.BladeL; // глубина выдавливания
                                thinProp.thin = false; // без тонкой стенки
                                entityBossExtr.Create(); // создадим операцию
                                
                                
                            }
                        }
                    }
                }
            }
            ksEntity iEdge = (ksEntity)Chisel.NewEntity((short)Obj3dType.o3d_edge);
            if (iEdge != null)
            {
                ksEdgeDefinition iEdgeDefenition = (ksEdgeDefinition)iEdge.GetDefinition();
                if (iEdgeDefenition !=null)
                {

                }
            }
        }
    }
}


