using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Deprembilgisi
{
    public partial class Mainform : Form
    {
        public Mainform()
        {
            InitializeComponent();
            DarkTitleBarClass.UseImmersiveDarkMode(Handle, true);
        }

        internal class DarkTitleBarClass
        {
            [DllImport("dwmapi.dll")]
            private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr,
            ref int attrValue, int attrSize);

            private const int DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1 = 19;
            private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;

            internal static bool UseImmersiveDarkMode(IntPtr handle, bool enabled)
            {
                if (IsWindows10OrGreater(17763))
                {
                    var attribute = DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1;
                    if (IsWindows10OrGreater(18985))
                    {
                        attribute = DWMWA_USE_IMMERSIVE_DARK_MODE;
                    }

                    int useImmersiveDarkMode = enabled ? 1 : 0;
                    return DwmSetWindowAttribute(handle, attribute, ref useImmersiveDarkMode, sizeof(int)) == 0;
                }

                return false;
            }
            private static bool IsWindows10OrGreater(int build = -1)
            {
                return Environment.OSVersion.Version.Major >= 10 && Environment.OSVersion.Version.Build >= build;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InternetKontrol();
        }

        public bool InternetKontrol()
        {
            try
            {
                System.Net.Sockets.TcpClient kontrol_client = new System.Net.Sockets.TcpClient("www.google.com.tr", 80);
                kontrol_client.Close();
                Veriler.Start();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Veriler y�klenemedi! L�tfen internet ba�lant�n�z� kontrol ediniz.", "Uyar�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private void Veriler_Tick(object sender, EventArgs e)
        {
            
            try
            {
                WebClient client = new WebClient();
                string htmlString = client.DownloadString("https://deprem.afad.gov.tr/last-earthquakes.html");
                HtmlAgilityPack.HtmlDocument htmlBelgesi = new HtmlAgilityPack.HtmlDocument();
                htmlBelgesi.OptionFixNestedTags = true;
                htmlBelgesi.LoadHtml(htmlString);
                HtmlAgilityPack.HtmlNodeCollection konum = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[1]/td[7]");
                HtmlAgilityPack.HtmlNodeCollection tarih = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[1]/td[1]");
                HtmlAgilityPack.HtmlNodeCollection Derinlik = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[1]/td[4]");
                HtmlAgilityPack.HtmlNodeCollection B�y�kl�k = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[1]/td[6]");
                string konums = "";
                konums += konum[0].InnerText;
                string tarihs = "";
                tarihs += tarih[0].InnerText;
                string Derin = "";
                Derin += Derinlik[0].InnerText + " km";
                string �iddet = "";
                �iddet += B�y�kl�k[0].InnerText;

                Konum.Text = konums;
                Tarih.Text = tarihs;
                derinlik.Text = Derin;
                b�y�kl�k.Text = �iddet;

                HtmlAgilityPack.HtmlNodeCollection konum2 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[2]/td[7]");
                HtmlAgilityPack.HtmlNodeCollection tarih2 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[2]/td[1]");
                HtmlAgilityPack.HtmlNodeCollection Derinlik2 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[2]/td[4]");
                HtmlAgilityPack.HtmlNodeCollection B�y�kl�k2 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[2]/td[6]");
                string konums2 = "";
                konums2 += konum2[0].InnerText;
                string tarihs2 = "";
                tarihs2 += tarih2[0].InnerText;
                string Derin2 = "";
                Derin2 += Derinlik2[0].InnerText + " km";
                string �iddet2 = "";
                �iddet2 += B�y�kl�k2[0].InnerText;

                label3.Text = �iddet2;
                label6.Text = konums2;
                label5.Text = tarihs2;
                label4.Text = Derin2;

                HtmlAgilityPack.HtmlNodeCollection konum3 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[3]/td[7]");
                HtmlAgilityPack.HtmlNodeCollection tarih3 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[3]/td[1]");
                HtmlAgilityPack.HtmlNodeCollection Derinlik3 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[3]/td[4]");
                HtmlAgilityPack.HtmlNodeCollection B�y�kl�k3 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[3]/td[6]");
                string konums3 = "";
                konums3 += konum3[0].InnerText;
                string tarihs3 = "";
                tarihs3 += tarih3[0].InnerText;
                string Derin3 = "";
                Derin3 += Derinlik3[0].InnerText + " km";
                string �iddet3 = "";
                �iddet3 += B�y�kl�k3[0].InnerText;

                label7.Text = �iddet3;
                label10.Text = konums3;
                label9.Text = tarihs3;
                label8.Text = Derin3;

                HtmlAgilityPack.HtmlNodeCollection konum4 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[4]/td[7]");
                HtmlAgilityPack.HtmlNodeCollection tarih4 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[4]/td[1]");
                HtmlAgilityPack.HtmlNodeCollection Derinlik4 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[4]/td[4]");
                HtmlAgilityPack.HtmlNodeCollection B�y�kl�k4 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[4]/td[6]");
                string konums4 = "";
                konums4 += konum4[0].InnerText;
                string tarihs4 = "";
                tarihs4 += tarih4[0].InnerText;
                string derin4 = "";
                derin4 += Derinlik4[0].InnerText + " km";
                string �iddet4 = "";
                �iddet4 += B�y�kl�k4[0].InnerText;

                label11.Text = �iddet4;
                label14.Text = konums4;
                label13.Text = tarihs4;
                label12.Text = derin4;

                HtmlAgilityPack.HtmlNodeCollection konum5 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[5]/td[7]");
                HtmlAgilityPack.HtmlNodeCollection tarih5 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[5]/td[1]");
                HtmlAgilityPack.HtmlNodeCollection Derinlik5 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[5]/td[4]");
                HtmlAgilityPack.HtmlNodeCollection B�y�kl�k5 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[5]/td[6]");
                string konums5 = "";
                konums5 += konum5[0].InnerText;
                string tarihs5 = "";
                tarihs5 += tarih5[0].InnerText;
                string derin5 = "";
                derin5 += Derinlik5[0].InnerText + " km";
                string �iddet5 = "";
                �iddet5 += B�y�kl�k5[0].InnerText;

                label27.Text = �iddet5;
                label30.Text = konums5;
                label29.Text = tarihs5;
                label28.Text = derin5;

                HtmlAgilityPack.HtmlNodeCollection konum6 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[6]/td[7]");
                HtmlAgilityPack.HtmlNodeCollection tarih6 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[6]/td[1]");
                HtmlAgilityPack.HtmlNodeCollection Derinlik6 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[6]/td[4]");
                HtmlAgilityPack.HtmlNodeCollection B�y�kl�k6 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[6]/td[6]");
                string konums6 = "";
                konums6 += konum6[0].InnerText;
                string tarihs6 = "";
                tarihs6 += tarih6[0].InnerText;
                string derin6 = "";
                derin6 += Derinlik6[0].InnerText + " km";
                string �iddet6 = "";
                �iddet6 += B�y�kl�k6[0].InnerText;

                label23.Text = �iddet6;
                label26.Text = konums6;
                label25.Text = tarihs6;
                label24.Text = derin6;

                HtmlAgilityPack.HtmlNodeCollection konum7 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[7]/td[7]");
                HtmlAgilityPack.HtmlNodeCollection tarih7 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[7]/td[1]");
                HtmlAgilityPack.HtmlNodeCollection Derinlik7 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[7]/td[4]");
                HtmlAgilityPack.HtmlNodeCollection B�y�kl�k7 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[7]/td[6]");
                string konums7 = "";
                konums7 += konum7[0].InnerText;
                string tarihs7 = "";
                tarihs7 += tarih7[0].InnerText;
                string derin7 = "";
                derin7 += Derinlik7[0].InnerText + " km";
                string �iddet7 = "";
                �iddet7 += B�y�kl�k7[0].InnerText;

                label19.Text = �iddet7;
                label22.Text = konums7;
                label21.Text = tarihs7;
                label20.Text = derin7;

                HtmlAgilityPack.HtmlNodeCollection konum8 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[8]/td[7]");
                HtmlAgilityPack.HtmlNodeCollection tarih8 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[8]/td[1]");
                HtmlAgilityPack.HtmlNodeCollection Derinlik8 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[8]/td[4]");
                HtmlAgilityPack.HtmlNodeCollection B�y�kl�k8 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[8]/td[6]");
                string konums8 = "";
                konums8 += konum8[0].InnerText;
                string tarihs8 = "";
                tarihs8 += tarih8[0].InnerText;
                string derin8 = "";
                derin8 += Derinlik8[0].InnerText + " km";
                string �iddet8 = "";
                �iddet8 += B�y�kl�k8[0].InnerText;

                label15.Text = �iddet8;
                label18.Text = konums8;
                label17.Text = tarihs8;
                label16.Text = derin8;

                HtmlAgilityPack.HtmlNodeCollection konum9 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[9]/td[7]");
                HtmlAgilityPack.HtmlNodeCollection tarih9 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[9]/td[1]");
                HtmlAgilityPack.HtmlNodeCollection Derinlik9 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[9]/td[4]");
                HtmlAgilityPack.HtmlNodeCollection B�y�kl�k9 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[9]/td[6]");
                string konums9 = "";
                konums9 += konum9[0].InnerText;
                string tarihs9 = "";
                tarihs9 += tarih9[0].InnerText;
                string derin9 = "";
                derin9 += Derinlik9[0].InnerText + " km";
                string �iddet9 = "";
                �iddet9 += B�y�kl�k9[0].InnerText;

                label43.Text = �iddet9;
                label46.Text = konums9;
                label45.Text = tarihs9;
                label44.Text = derin9;


                HtmlAgilityPack.HtmlNodeCollection konum10 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[10]/td[7]");
                HtmlAgilityPack.HtmlNodeCollection tarih10= htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[10]/td[1]");
                HtmlAgilityPack.HtmlNodeCollection Derinlik10 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[10]/td[4]");
                HtmlAgilityPack.HtmlNodeCollection B�y�kl�k10 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[10]/td[6]");
                string konums10 = "";
                konums10 += konum10[0].InnerText;
                string tarihs10 = "";
                tarihs10 += tarih10[0].InnerText;
                string derin10 = "";
                derin10 += Derinlik10[0].InnerText + " km";
                string �iddet10 = "";
                �iddet10 += B�y�kl�k10[0].InnerText;

                label39.Text = �iddet10;
                label42.Text = konums10;
                label41.Text = tarihs10;
                label40.Text = derin10;

                HtmlAgilityPack.HtmlNodeCollection konum11 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[11]/td[7]");
                HtmlAgilityPack.HtmlNodeCollection tarih11 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[11]/td[1]");
                HtmlAgilityPack.HtmlNodeCollection Derinlik11 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[11]/td[4]");
                HtmlAgilityPack.HtmlNodeCollection B�y�kl�k11 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[11]/td[6]");
                string konums11 = "";
                konums11 += konum11[0].InnerText;
                string tarihs11 = "";
                tarihs11 += tarih11[0].InnerText;
                string derin11 = "";
                derin11 += Derinlik11[0].InnerText + " km";
                string �iddet11 = "";
                �iddet11 += B�y�kl�k11[0].InnerText;

                label35.Text = �iddet11;
                label38.Text = konums11;
                label37.Text = tarihs11;
                label36.Text = derin11;

                HtmlAgilityPack.HtmlNodeCollection konum12 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[12]/td[7]");
                HtmlAgilityPack.HtmlNodeCollection tarih12 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[12]/td[1]");
                HtmlAgilityPack.HtmlNodeCollection Derinlik12 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[12]/td[4]");
                HtmlAgilityPack.HtmlNodeCollection B�y�kl�k12 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[12]/td[6]");
                string konums12 = "";
                konums12 += konum12[0].InnerText;
                string tarihs12 = "";
                tarihs12 += tarih12[0].InnerText;
                string derin12 = "";
                derin12 += Derinlik12[0].InnerText + " km";
                string �iddet12 = "";
                �iddet12 += B�y�kl�k12[0].InnerText;

                label31.Text = �iddet12;
                label34.Text = konums12;
                label33.Text = tarihs12;
                label32.Text = derin12;

                HtmlAgilityPack.HtmlNodeCollection konum13 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[13]/td[7]");
                HtmlAgilityPack.HtmlNodeCollection tarih13 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[13]/td[1]");
                HtmlAgilityPack.HtmlNodeCollection Derinlik13 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[13]/td[4]");
                HtmlAgilityPack.HtmlNodeCollection B�y�kl�k13 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[13]/td[6]");
                string konums13 = "";
                konums13 += konum13[0].InnerText;
                string tarihs13 = "";
                tarihs13 += tarih13[0].InnerText;
                string derin13 = "";
                derin13 += Derinlik13[0].InnerText + " km";
                string �iddet13 = "";
                �iddet13 += B�y�kl�k13[0].InnerText;

                label59.Text = �iddet13;
                label62.Text = konums13;
                label61.Text = tarihs13;
                label60.Text = derin13;

                HtmlAgilityPack.HtmlNodeCollection konum14 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[14]/td[7]");
                HtmlAgilityPack.HtmlNodeCollection tarih14 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[14]/td[1]");
                HtmlAgilityPack.HtmlNodeCollection Derinlik14 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[14]/td[4]");
                HtmlAgilityPack.HtmlNodeCollection B�y�kl�k14 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[14]/td[6]");
                string konums14 = "";
                konums14 += konum14[0].InnerText;
                string tarihs14 = "";
                tarihs14+= tarih14[0].InnerText;
                string derin14 = "";
                derin14 += Derinlik14[0].InnerText + " km";
                string �iddet14 = "";
                �iddet14 += B�y�kl�k14[0].InnerText;

                label55.Text = �iddet14;
                label58.Text = konums14;
                label57.Text = tarihs14;
                label56.Text = derin14;

                HtmlAgilityPack.HtmlNodeCollection konum15 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[15]/td[7]");
                HtmlAgilityPack.HtmlNodeCollection tarih15 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[15]/td[1]");
                HtmlAgilityPack.HtmlNodeCollection Derinlik15 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[15]/td[4]");
                HtmlAgilityPack.HtmlNodeCollection B�y�kl�k15 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[15]/td[6]");
                string konums15 = "";
                konums15 += konum15[0].InnerText;
                string tarihs15 = "";
                tarihs15 += tarih15[0].InnerText;
                string derin15 = "";
                derin15 += Derinlik15[0].InnerText + " km";
                string �iddet15 = "";
                �iddet15 += B�y�kl�k15[0].InnerText;

                label51.Text = �iddet15;
                label54.Text = konums15;
                label53.Text = tarihs15;
                label52.Text = derin15;

                HtmlAgilityPack.HtmlNodeCollection konum16= htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[16]/td[7]");
                HtmlAgilityPack.HtmlNodeCollection tarih16 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[16]/td[1]");
                HtmlAgilityPack.HtmlNodeCollection Derinlik16 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[16]/td[4]");
                HtmlAgilityPack.HtmlNodeCollection B�y�kl�k16 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[16]/td[6]");
                string konums16 = "";
                konums16 += konum16[0].InnerText;
                string tarihs16 = "";
                tarihs16 += tarih16[0].InnerText;
                string derin16 = "";
                derin16 += Derinlik16[0].InnerText + " km";
                string �iddet16 = "";
                �iddet16 += B�y�kl�k16[0].InnerText;

                label47.Text = �iddet16;
                label50.Text = konums16;
                label49.Text = tarihs16;
                label48.Text = derin16;

                HtmlAgilityPack.HtmlNodeCollection konum17 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[17]/td[7]");
                HtmlAgilityPack.HtmlNodeCollection tarih17 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[17]/td[1]");
                HtmlAgilityPack.HtmlNodeCollection Derinlik17 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[17]/td[4]");
                HtmlAgilityPack.HtmlNodeCollection B�y�kl�k17 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[17]/td[6]");
                string konums17 = "";
                konums17 += konum16[0].InnerText;
                string tarihs17 = "";
                tarihs17 += tarih17[0].InnerText;
                string derin17 = "";
                derin17 += Derinlik17[0].InnerText + " km";
                string �iddet17 = "";
                �iddet17 += B�y�kl�k17[0].InnerText;

                label75.Text = �iddet17;
                label78.Text = konums17;
                label77.Text = tarihs17;
                label76.Text = derin17;

                HtmlAgilityPack.HtmlNodeCollection konum18 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[18]/td[7]");
                HtmlAgilityPack.HtmlNodeCollection tarih18 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[18]/td[1]");
                HtmlAgilityPack.HtmlNodeCollection Derinlik18= htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[18]/td[4]");
                HtmlAgilityPack.HtmlNodeCollection B�y�kl�k18 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[18]/td[6]");
                string konums18 = "";
                konums18 += konum18[0].InnerText;
                string tarihs18 = "";
                tarihs18 += tarih18[0].InnerText;
                string derin18 = "";
                derin18 += Derinlik18[0].InnerText + " km";
                string �iddet18 = "";
                �iddet18 += B�y�kl�k18[0].InnerText;

                label71.Text = �iddet18;
                label74.Text = konums18;
                label73.Text = tarihs18;
                label72.Text = derin18;

                HtmlAgilityPack.HtmlNodeCollection konum19 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[19]/td[7]");
                HtmlAgilityPack.HtmlNodeCollection tarih19 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[19]/td[1]");
                HtmlAgilityPack.HtmlNodeCollection Derinlik19 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[19]/td[4]");
                HtmlAgilityPack.HtmlNodeCollection B�y�kl�k19 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[19]/td[6]");
                string konums19 = "";
                konums19 += konum19[0].InnerText;
                string tarihs19 = "";
                tarihs19 += tarih19[0].InnerText;
                string derin19 = "";
                derin19 += Derinlik19[0].InnerText + " km";
                string �iddet19 = "";
                �iddet19 += B�y�kl�k19[0].InnerText;

                label67.Text = �iddet19;
                label70.Text = konums19;
                label69.Text = tarihs19;
                label68.Text = derin19;

                HtmlAgilityPack.HtmlNodeCollection konum20 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[20]/td[7]");
                HtmlAgilityPack.HtmlNodeCollection tarih20 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[20]/td[1]");
                HtmlAgilityPack.HtmlNodeCollection Derinlik20 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[20]/td[4]");
                HtmlAgilityPack.HtmlNodeCollection B�y�kl�k20 = htmlBelgesi.DocumentNode.SelectNodes("/html/body/div[3]/table/tbody/tr[20]/td[6]");
                string konums20 = "";
                konums20 += konum20[0].InnerText;
                string tarihs20 = "";
                tarihs20 += tarih20[0].InnerText;
                string derin20 = "";
                derin20 += Derinlik20[0].InnerText + " km";
                string �iddet20 = "";
                �iddet20 += B�y�kl�k20[0].InnerText;

                label63.Text = �iddet20;
                label66.Text = konums20;
                label65.Text = tarihs20;
                label64.Text = derin20;

                Veriler.Stop();
            }
            catch
            {
                MessageBox.Show("Veriler y�klenemedi! L�tfen internet ba�lant�n�z� kontrol ediniz.", "Ba�lant� Hatas�");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InternetKontrol();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }
           
    }
}