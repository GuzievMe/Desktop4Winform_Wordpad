using Newtonsoft.Json;
using System.Drawing;
using System.Net;
using System.IO;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsHomeApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        List<string> Colors = new() { Color.Aqua.ToString(),  "Black", "White", "Yellow", "Green", "Blue", "Red", "RebeccaPurple" };
        List<string> Fonts = new() { FontStyle.Bold.ToString() , FontStyle.Italic.ToString(), FontStyle.Underline.ToString(), FontStyle.Regular.ToString() };
        List<string> Sizess = new() { "10", "14", "20", "25", "30" };
        int[] Sizes = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 14, 29, 30, 40  };
        string[] fontSizes = { "8", "10", "12", "14", "16" };
        
        

        private void Form1_Load(object sender, EventArgs e)
        {
            //listBox1.Items.AddRange(persons.ToArray());
            comboBox3.Items.AddRange(Colors.ToArray());
            comboBox2.Items.AddRange(Fonts.ToArray());
            //comboBox1.Items.AddRange(Sizess.ToArray());
            comboBox1.Items.AddRange(fontSizes);


            WebClient wc = new WebClient(); 
            var bytes = wc.DownloadData("https://tr.wikipedia.org/wiki/Leonardo_da_Vinci");
            var str = Encoding.Default .GetString(bytes);
            File.WriteAllText("wrt.txt" ,str);
        }




        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null)
            {
                if (comboBox2.SelectedItem.ToString() == "Regular")
                    richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                else if (comboBox2.SelectedItem.ToString() == "Bold")
                    richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                else if (comboBox2.SelectedItem.ToString() == "Italic")
                    richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Italic);
                else if (comboBox2.SelectedItem.ToString() == "Underline")
                    richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Underline);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string selectedFontSize = comboBox1.SelectedItem.ToString()!;

                if (float.TryParse(selectedFontSize, out float fontSize))
                {
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, fontSize);
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem != null)
            {
                string selectedColorName = comboBox3.SelectedItem.ToString()!;
                // Color selectedColor = Color.FromName(selectedColorName);

                richTextBox1.SelectionColor = Color.FromName(selectedColorName);
            }
        }


        bool isBold = false, isUnderline = false, isItalic = false;

       

        private void button1_Click(object sender, EventArgs e)
        {
            if (isBold) { richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular); isBold = false; return; }
            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold); isBold = true;
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            if (isUnderline  ) { richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular); isUnderline  = false; return; }
            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Underline ); isUnderline  = true;
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            if(isItalic ) { richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular); isItalic = false; return; }
            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Italic); isItalic = true;
        }

       

        //////////////////////////Alignment Buttons
        private void button4_Click(object sender, EventArgs e)
        {


            
            HorizontalAlignment alignment = HorizontalAlignment.Left;

            richTextBox1.SelectionAlignment = alignment;

        }

        

        private void button5_Click(object sender, EventArgs e)
        {
            HorizontalAlignment alignment = HorizontalAlignment.Center;

            richTextBox1.SelectionAlignment = alignment;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            HorizontalAlignment alignment = HorizontalAlignment.Right ;

            richTextBox1.SelectionAlignment = alignment;
        }





        ///////////Load ve Save olunmasi
        private void button7_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = textBox1.Text;
            if(openFileDialog1.ShowDialog() == DialogResult.OK )
            {
                var str = File.ReadAllText(openFileDialog1.FileName);
                richTextBox1.Text = str;
            }
            //var fs = File.ReadAllText(textBox1.Text);
            //richTextBox1.Text = JsonConvert.DeserializeObject<string>(fs);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string str = JsonConvert.SerializeObject(richTextBox1.Text, Formatting.Indented);
            File.WriteAllText(textBox2.Text, str);

            // if (saveFileDialog1.ShowDialog() == DialogResult.OK )
            //{
                //saveFileDialog1.FileName = textBox2.Text;
                //File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);    
            //}
        }


    }
}