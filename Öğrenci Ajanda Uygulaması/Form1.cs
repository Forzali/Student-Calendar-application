using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Öğrenci_Ajanda_Uygulaması
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e) //Uygulama açıldığında ilk burası çalışacak
        {
            kayitSayYaz();
        }

        private void button8_Click(object sender, EventArgs e) //Not Defterini açar
        {
            System.Diagnostics.Process.Start(@"C:\Windows\System32\notepad.exe");
        }
        private void kayitSayYaz() //kayıtlı kişi sayısını sayıp ekrana yazdıracak
        {
            lblKayit.Text = listView1.Items.Count.ToString();
            progressBar1.Value = listView1.Items.Count;
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            bool ara = false; //girilen numara aranacak
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].SubItems[0].Text== textBox1.Text) //girilen öğrenci numarası listviewdeki öğrenci numaraları ile karşılaştırılıyor 
                {
                    ara = true;
                    textBox2.Text = listView1.Items[i].SubItems[1].Text;
                    comboBox1.Text = listView1.Items[i].SubItems[2].Text;
                    if (listView1.Items[i].SubItems[3].Text == "Bay") ;
                    radioButton1.Checked = true;
                    if (listView1.Items[i].SubItems[3].Text == "Bayan") ;
                    radioButton2.Checked = true;
                    textBox3.Text = listView1.Items[i].SubItems[4].Text;
                    textBox4.Text = listView1.Items[i].SubItems[5].Text;
                    textBox5.Text = listView1.Items[i].SubItems[6].Text;
                    listView1.Items[i].Selected = true; // ListViewde seçili olarak gözükecek
                    textBox2.Enabled = false; // bütün bilgiler yerleştirildikten sonra kutular kilitlendi
                    textBox3.Enabled = false;
                    textBox4.Enabled = false;
                    textBox5.Enabled = false;
                    comboBox1.Enabled = false;
                    groupBox1.Enabled = false;
                }
            }
            if (ara == false) MessageBox.Show("Aranan kişi bulunamadı...", "Kayıt Yok", MessageBoxButtons.OK, MessageBoxIcon.Error);// kayıt bulunamadığı için ekrana hata yazısı yazdırıldı
        }

        private void button2_Click(object sender, EventArgs e) // ekleme işlemi yapılacak
        {
            string no = "", adsoyad = "", bolum = "", cinsiyet = "", memleket = "", tel = "", mail = "";
            no = textBox1.Text;
            adsoyad = textBox2.Text;
            bolum = comboBox1.Text;
            if (radioButton1.Checked == true)
                cinsiyet = radioButton1.Text;
            if (radioButton2.Checked == true)
                cinsiyet = radioButton2.Text;
            memleket = textBox3.Text;
            tel = textBox4.Text;
            mail = textBox5.Text;
            string[] kayit = { no, adsoyad, bolum, cinsiyet, memleket, tel, mail };
            bool kontrol = false;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].SubItems[0].Text == textBox1.Text)  //öğrenci numaraları listviewdeki numaralarla karşılaştırılıyor
                {
                    kontrol = true;
                    MessageBox.Show(textBox1.Text + " Öğrenci Numarası Zaten Kayıtlıdır.!!", "Kayıt Hatası",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
            if(kontrol==false)
            {
                ListViewItem lst = new ListViewItem(kayit);
                if (no != "" && adsoyad != "" && bolum != "" && cinsiyet != "" && memleket != "" && tel != "" && mail != "")
                {
                    listView1.Items.Add(lst);
                }
                else MessageBox.Show("Boş Bilgi Bırakılamaz !", "Eksik Bilgi Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            kayitSayYaz();
        }

        private void button3_Click(object sender, EventArgs e)//CheckBox İle silme işlemi yapılacak
        {
            int secim = listView1.CheckedItems.Count;
            foreach (ListViewItem secilikayitbilgisi in listView1.CheckedItems)// kayıt bilgisi secilikayitbilgisi nde tutulacak
            {
                secilikayitbilgisi.Remove();
            }
            MessageBox.Show(secim.ToString() + " Adet kayıt Silindi !!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);//ekrana kaç kayıt silindiği bilgisi verildi.
            kayitSayYaz();
        }

        private void button4_Click(object sender, EventArgs e) //normal sillme işlemi 
        {
            int secim = listView1.SelectedItems.Count;
            foreach (ListViewItem secilikayitbilgisi in listView1.SelectedItems)// kayıt bilgisi secilikayitbilgisi nde tutulacak
            {
                secilikayitbilgisi.Remove();
            }
            MessageBox.Show(secim.ToString() + " Adet kayıt Silindi !!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);//ekrana kaç kayıt silindiği bilgisi verildi.
            kayitSayYaz();
        }

        private void button5_Click(object sender, EventArgs e) //Bütün Kayıtları silme işlemi
        {
            listView1.Items.Clear();
            kayitSayYaz();
        }

        private void button6_Click(object sender, EventArgs e) // Yeni kayıt için Butonları aktifleştirme Kodu
        {
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            comboBox1.Enabled = true;
            groupBox1.Enabled = true;
        }

        private void button11_Click(object sender, EventArgs e) //Font Değiştirme İşlemi
        {
            FontDialog fontDegis = new FontDialog();
            fontDegis.ShowDialog();
            textBox1.Font = fontDegis.Font;
            textBox2.Font = fontDegis.Font;
            textBox3.Font = fontDegis.Font;
            textBox4.Font = fontDegis.Font;
            textBox5.Font = fontDegis.Font;
            comboBox1.Font = fontDegis.Font;
            listView1.Font = fontDegis.Font;
        }

        private void button7_Click(object sender, EventArgs e) // Hesap Makinesini Açar
        {
            System.Diagnostics.Process.Start(@"C:\Windows\System32\calc.exe");
        }

        private void button10_Click(object sender, EventArgs e) //form renk değişme
        {
            ColorDialog renkDegis = new ColorDialog();
            renkDegis.ShowDialog();
            this.BackColor = renkDegis.Color;
        }

        private void button9_Click(object sender, EventArgs e) //media playeri açar
        {
            System.Diagnostics.Process.Start(@"C:\Program Files (x86)\Windows Media Player\wmplayer.exe");
        }

        private void button12_Click(object sender, EventArgs e) // Paint Uygulamasını klavyesini açar
        {
            System.Diagnostics.Process.Start(@"C:\WINDOWS\system32\mspaint.exe");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
