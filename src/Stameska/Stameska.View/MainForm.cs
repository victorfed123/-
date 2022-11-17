using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Stameska.Model;


namespace Stameska.View
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// переменная ошибки ввода параментра длины ручки
        /// </summary>
        private string _errorTextBoxHangleL = string.Empty;
        private string _errorTextBoxBladeL = string.Empty;
        private string _errorTextBoxBladeH = string.Empty;
        private string _errorTextBoxRing = string.Empty;
        private string _errorTextBoxChiselW = string.Empty;

        private readonly Color _errorColor = Color.LightPink;
        private readonly Color _trueColor = Color.White;

        private ChiselData _chiselData = new ChiselData();

        private KompasConnector _kompasApp;

        private Manager _manager;

       
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Вывод информации об ошибке
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="errorMessage"></param>
        /// <param name="currentTextBox"></param>
        private void OutputAfterErrorTextBox(Exception exception, string errorMessage, TextBox currentTextBox)
        {
            currentTextBox.BackColor = _errorColor;
            errorMessage += exception.Message;
            toolTipInformation.SetToolTip(currentTextBox, errorMessage);
        }

        /// <summary>
        /// Обрабатывает нажатие на клавиатуру 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="currentTextBox"></param>
        private void IfKeyPress(KeyPressEventArgs e, TextBox currentTextBox)
        {
            if (Char.IsNumber(e.KeyChar) | ((e.KeyChar == Convert.ToChar(",")) &&
            !currentTextBox.Text.Contains(",")) | e.KeyChar == '\b')
            {
                return;
            }
            else e.Handled = true;
        }

        /// <summary>
        /// заносит данные из TextBox в ChiselData
        /// </summary>
        private void ReloadChiselData(TextBox currentTextBox, double chiselDataParameter)
        {          
            if ((HangleTextBox.Text != string.Empty) && (chiselDataParameter == _chiselData.HangleL) && (currentTextBox == HangleTextBox))
            {
                _chiselData.HangleL = Convert.ToDouble(HangleTextBox.Text);
            }
            if ((BladeLengthTextBox.Text != string.Empty) && (chiselDataParameter == _chiselData.BladeL) && (currentTextBox == BladeLengthTextBox))
            {
                _chiselData.BladeL = Convert.ToDouble(BladeLengthTextBox.Text);
            }
            if ((BladeHeigthTextBox.Text != string.Empty) && (chiselDataParameter == _chiselData.BladeH) && (currentTextBox == BladeHeigthTextBox))
            {
                _chiselData.BladeH = Convert.ToDouble(BladeHeigthTextBox.Text);
            }
            if ((RingTextBox.Text != string.Empty) && (chiselDataParameter == _chiselData.RingD) && (currentTextBox == RingTextBox))
            {
                _chiselData.RingD = Convert.ToDouble(RingTextBox.Text);
            }
            if ((ChiselWidthTextBox.Text != string.Empty) && (chiselDataParameter == _chiselData.ChiselW) && (currentTextBox == ChiselWidthTextBox))
            {
                _chiselData.ChiselW = Convert.ToDouble(ChiselWidthTextBox.Text);
            }
        }

        /// <summary>
        /// активация кнопки createbutton
        /// </summary>
        private void OnOffCreateButton()
        {
            if ((_chiselData.ChiselW != 0 && _chiselData.BladeH != 0 && _chiselData.BladeL != 0
            && _chiselData.HangleL != 0 && _chiselData.RingD != 0) && (_errorTextBoxHangleL == ""
            && _errorTextBoxBladeL == "" && _errorTextBoxBladeH == "" && _errorTextBoxRing == ""
            && _errorTextBoxChiselW == ""))
            {
                CreateButton.Enabled = true;
            }
            else
            {
                CreateButton.Enabled = false;
            }
        }

        /// <summary>
        /// Проверяет верность данных во всех полях при изминении одного
        /// </summary>
        private void CheckAfterInput()
        {
            OnOffCreateButton();
            string errorMesaage = string.Empty;
            IfTextChanged(HangleTextBox, errorMesaage, _chiselData.HangleL);
            IfTextChanged(BladeHeigthTextBox, errorMesaage, _chiselData.BladeH);
            IfTextChanged(BladeLengthTextBox, errorMesaage, _chiselData.BladeL);
            IfTextChanged(RingTextBox, errorMesaage, _chiselData.RingD);
            IfTextChanged(ChiselWidthTextBox, errorMesaage, _chiselData.ChiselW);
        }

        /// <summary>
        /// функция выхода из TextBox
        /// </summary>
        /// <param name="currentTextBox"></param>
        /// <param name="errorMessage"></param>
        private void IfTextBoxLeave(TextBox currentTextBox, string errorMessage)
        {
            try
            {
                EndsWithComma(currentTextBox);
            }
            catch (ArgumentException exception)
            {
                OutputAfterErrorTextBox(exception, errorMessage, currentTextBox);
            }
            currentTextBox.Text = currentTextBox.Text.TrimStart('0');
        }

        /// <summary>
        /// Ставит ноль, если в начале стоит запятая
        /// </summary>
        /// <param name="cuurentTextBox"></param>
        private void StartstWithComma(TextBox cuurentTextBox)
        {
            if (Convert.ToString(cuurentTextBox.Text).StartsWith(","))
            {
                if (cuurentTextBox.Text.Length != 0)
                {
                    cuurentTextBox.Text = cuurentTextBox.Text.Insert(0, "0");
                }
            }
        }

        /// <summary>
        /// Удаляет запятую, если она стоит в конце
        /// </summary>
        /// <param name="cuurentTextBox"></param>
        private void EndsWithComma(TextBox cuurentTextBox)
        {
            if (Convert.ToString(cuurentTextBox.Text).EndsWith(","))
            {
                if (cuurentTextBox.Text.Length != 0)
                {
                    cuurentTextBox.Text = cuurentTextBox.Text.Remove(cuurentTextBox.Text.Length - 1);
                }
            }
        }

        /// <summary>
        /// функция корректировки данных при вводе в текущий TextBox
        /// </summary>
        /// <param name="currentTextBox"></param>
        /// <param name="errorMessage"></param>
        private void IfTextChanged(TextBox currentTextBox, string errorMessage, double chiselDataParameter)
        {
            try
            {
                PointValidation(currentTextBox);
                ReloadChiselData(currentTextBox, chiselDataParameter);
                currentTextBox.BackColor = _trueColor;
                toolTipInformation.SetToolTip(currentTextBox, string.Empty);
                errorMessage = string.Empty;
                /*                OKButtonON();
                */
            }
            catch (Exception exception)
            {
                OutputAfterErrorTextBox(exception, errorMessage, currentTextBox);
            }

            StartstWithComma(currentTextBox);
        }

        /// <summary>
        /// Запрещает вводить все символы кроме цифр и одной запятой, заменяет точку на запятую
        /// </summary>
        /// <param name="textBox"></param>
        private void PointValidation(TextBox textBox)
        {
            string str = textBox.Text;
            string tmp = textBox.Text.Trim();
            string outS = string.Empty;
            bool point = true;
            foreach (char ch in tmp)

                if (Char.IsDigit(ch) || (ch == ',' && point))
                {
                    outS += ch;
                    if (ch == ',')
                        point = false;
                }

            textBox.Text = outS;
            textBox.SelectionStart = outS.Length;

            if (str.Contains("."))
            {
                string s = str.Replace(".", ",");
                textBox.Clear();
                textBox.AppendText(str.Replace(".", ","));

            }
        }

        /// <summary>
        /// обновляет текст в HangleTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HangleTextBox_TextChanged(object sender, EventArgs e)
        {
            IfTextChanged(HangleTextBox, _errorTextBoxHangleL, _chiselData.HangleL);
            CheckAfterInput();
        }

        /// <summary>
        /// функция выхода из HangleTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HangleTextBox_Leave(object sender, EventArgs e)
        {
            IfTextBoxLeave(HangleTextBox, _errorTextBoxHangleL);
            CheckAfterInput();
        }

        /// <summary>
        /// обработчик события нажатия на клавишу в HangleTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HangleTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            IfKeyPress(e, HangleTextBox);
        }

        /// <summary>
        /// Валидация для BladeLengthTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BladeLengthTextBox_TextChanged(object sender, EventArgs e)
        {
            IfTextChanged(BladeLengthTextBox, _errorTextBoxBladeL, _chiselData.BladeL);
            CheckAfterInput();
        }

        private void BladeLengthTextBox_Leave(object sender, EventArgs e)
        {
            IfTextBoxLeave(BladeLengthTextBox, _errorTextBoxBladeL);
            CheckAfterInput();
        }

        private void BladeLengthTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            IfKeyPress(e, BladeLengthTextBox);
        }

        /// <summary>
        /// Валидация для  BladeHeigthTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BladeHeigthTextBox_TextChanged(object sender, EventArgs e)
        {
            IfTextChanged(BladeHeigthTextBox, _errorTextBoxBladeH, _chiselData.BladeH);
            CheckAfterInput();
        }

        private void BladeHeigthTextBox_Leave(object sender, EventArgs e)
        {
            IfTextBoxLeave(BladeHeigthTextBox, _errorTextBoxBladeH);
            CheckAfterInput();
        }

        private void BladeHeigthTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            IfKeyPress(e, BladeHeigthTextBox);
        }

        /// <summary>
        /// Валидация для RingTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RingTextBox_TextChanged(object sender, EventArgs e)
        {
            IfTextChanged(RingTextBox, _errorTextBoxRing, _chiselData.RingD);
            CheckAfterInput();
        }

        private void RingTextBox_Leave(object sender, EventArgs e)
        {
            IfTextBoxLeave(RingTextBox, _errorTextBoxRing);
            CheckAfterInput();
        }

        private void RingTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            IfKeyPress(e, RingTextBox);
        }

        /// <summary>
        /// Валидация для ChiselWidthTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChiselWidthTextBox_TextChanged(object sender, EventArgs e)
        {
            IfTextChanged(ChiselWidthTextBox, _errorTextBoxChiselW, _chiselData.ChiselW);
            CheckAfterInput();
        }

        private void ChiselWidthTextBox_Leave(object sender, EventArgs e)
        {
            IfTextBoxLeave(ChiselWidthTextBox, _errorTextBoxChiselW);
            CheckAfterInput();
        }

        private void ChiselWidthTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            IfKeyPress(e, ChiselWidthTextBox);
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            _kompasApp = new KompasConnector();
            if (!_kompasApp.CreateDocument3D())
            {
                return;
            }
            _manager = new Manager(_kompasApp);

            if (_manager != null)
            {
                _manager.BuildModel(_chiselData);
            }
        }
    }
}
