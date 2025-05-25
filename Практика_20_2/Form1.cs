using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Практика_20;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.CheckBox;
using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;


namespace Практика_20_2
{
    public partial class EditTuristForm : Form
    {


        private BindingList<TouristVoucher> touristPutivka = new BindingList<TouristVoucher> ();
        public TouristVoucher Voucher { get; private set; }


        private BindingList<SanatoryPutivka> sanatorPutivka = new BindingList<SanatoryPutivka>();

        public SanatoryPutivka Pacient { get; private set; }


        private string turistFile = "Туристические_Путевки.txt";
        private string sanatorFile = "Санаторные_Путевки.txt";


        private List<string> validCategories = new List<string>
        {
        "Горный", "Пляжный", "Экскурсионный", "Лечебный", "Круизный"
        };

        public EditTuristForm(TouristVoucher voucher = null, SanatoryPutivka pacient = null)
        {
            InitializeComponent();

            category.Items.AddRange(validCategories.ToArray());

            dataGridView1.DataSource = touristPutivka; // привязка данных
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;

            dataGridView2.DataSource = sanatorPutivka;
            dataGridView2.Columns.Clear();
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.AllowUserToAddRows = false;

            SetupDataGridViews();

            Voucher = voucher ?? new TouristVoucher("", 0, 0, false, "", false); // Сохраняем переданную путевку                                                                       // Заполняем поля формы данными из путевки

            Pacient = pacient ?? new SanatoryPutivka("", 0, 0, false, "");

            if (voucher != null) // Режим редактирования
            {
                nameTextBox.Text = voucher.NameTravel;
                durationNumeric.Value = voucher.Duration;
                costNumeric.Value = voucher.Price;
                category.Text = voucher.CategoryRoute;
                spravka.Checked = voucher.Spravka;
            }

            if (pacient != null)
            {
                nameSanTextBox.Text = pacient.NameTravel;
                duratNumeric.Value = pacient.Duration;
                costNum.Value = pacient.Price;
                zabolevanie.Text = pacient.Disease;
            }
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            tabPage2.Text = "Туристическая путевка";
            tabPage3.Text = "Санаторная путевка";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            
        }

        private void SaveData()
        {
            try
            {
                using (var stream = File.CreateText(turistFile))
                {
                    foreach (var voucher in touristPutivka)
                    {
                        stream.WriteLine($"|Название: {voucher.NameTravel}\n|Продолжительность: {voucher.Duration}\n|Цена: {voucher.Price}\n" +
                            $"|Необходимость справки: {voucher.Spravka}\n|Категория: {voucher.CategoryRoute}\n\n\n\n");
                    }
                }

                using (var stream = File.CreateText(sanatorFile)) 
                {
                    foreach(var pacient in sanatorPutivka)
                    {
                        stream.WriteLine($"|Название: {pacient.NameTravel}\n|Продолжительность: {pacient.Duration}\n|Цена: {pacient.Price}\n" +
                            $"|Заболевание: {pacient.Disease}\n\n\n\n");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения данных!");
            }
        }
        private void SetupDataGridViews()
        {
            // для туристических путевок
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "NameTravel",  // Свойство класса
                HeaderText = "Название путевки"  // Красивый заголовок
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Duration",
                HeaderText = "Длительность (дни)"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Price",
                HeaderText = "Стоимость"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "CategoryRoute",
                HeaderText = "Категория маршрута"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Spravka",
                HeaderText = "Справка"
            });

            // для санаторных
            dataGridView2.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "NameTravel",  // Свойство класса
                HeaderText = "Название путевки"  // Красивый заголовок
            });

            dataGridView2.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Duration",
                HeaderText = "Длительность (дни)"
            });

            dataGridView2.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Price",
                HeaderText = "Стоимость"
            });

            dataGridView2.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Disease",
                HeaderText = "Заболевание"
            });

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        // кнопка добавления тур путевки
        private void button2_Click(object sender, EventArgs e)
        {
            // Проверка заполненности полей
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Введите название путевки");
                return;
            }

            if (durationNumeric.Value <= 0)
            {
                MessageBox.Show("Продолжительность должна быть положительным числом");
                return;
            }

            if (costNumeric.Value <= 0)
            {
                MessageBox.Show("Стоимость должна быть положительным числом");
                return;
            }

            if (category.SelectedItem == null)
            {
                MessageBox.Show("Необходимо выбрать категорию маршрута");
                return;
            }

            string selectedCategory = category.SelectedItem.ToString();

            var newVoucher = new TouristVoucher(
                nameTextBox.Text,
                (int)durationNumeric.Value,
                (int)costNumeric.Value,
                false,
                selectedCategory,
                spravka.Checked);

            touristPutivka.Add(newVoucher);
            SaveData();

            nameTextBox.Text = "";
            durationNumeric.Value = 0;
            costNumeric.Value = 0;
            category.SelectedIndex = -1;
            spravka.Checked = false;
        }

        // кнопка редактирования тур пут
        private void button1_Click_2(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите путевку для редактирования.");
                return;
            }

            var turist = (TouristVoucher)dataGridView1.SelectedRows[0].DataBoundItem;

            var form = new EditTuristForm(turist);

            if (form.ShowDialog() == DialogResult.OK)
            {
                int index = touristPutivka.IndexOf(turist);
                touristPutivka[index] = form.Voucher;
                SaveData();
            }
        }
        // кнопка удаления тур пут
        private void button4_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите путевку для удаления.");
                return;
            }

            var turist = (TouristVoucher)dataGridView1.SelectedRows[0].DataBoundItem;
            touristPutivka.Remove(turist);
            SaveData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Проверка заполненности полей
            if (string.IsNullOrWhiteSpace(nameSanTextBox.Text))
            {
                MessageBox.Show("Введите название путевки");
                return;
            }

            if (duratNumeric.Value <= 0)
            {
                MessageBox.Show("Продолжительность должна быть положительным числом");
                return;
            }

            if (costNum.Value <= 0)
            {
                MessageBox.Show("Стоимость должна быть положительным числом");
                return; 
            }

            if (string.IsNullOrWhiteSpace(zabolevanie.Text))
            {
                MessageBox.Show("Введите заболевание");
                return;
            }


            var newPacient = new SanatoryPutivka(
                nameSanTextBox.Text,
                (int)duratNumeric.Value,
                (int)costNum.Value,
                false,
                zabolevanie.Text);

            sanatorPutivka.Add(newPacient);
            SaveData();

            nameSanTextBox.Text = "";
            duratNumeric.Value = 0;
            costNum.Value = 0;
            category.SelectedIndex = -1;
            zabolevanie.Text = "";
        }
    }
}
