using System.Net;
using Newtonsoft.Json;

namespace Nyoba
{
    public partial class Form1 : Form
    {
        public class University
        {
            public List<string> domains { get; set; }
            public string alpha_two_code { get; set; }
            public List<string> web_pages { get; set; }
            public string name { get; set; }
            public string state_province { get; set; }
            public string country { get; set; }
        }
        public Form1()
        {
            InitializeComponent();
            WebRequestLoad();
        }
        public void WebRequestLoad()
        {
            //Membuat permintaan web ke URL yang ditentukan, dalam hal ini, API yang mengembalikan daftar universitas di Indonesia
            var request = System.Net.WebRequest.Create("http://universities.hipolabs.com/search?country=Indonesia");

            //Mengirimkan permintaan dan menadaptkan respon dari server
            HttpWebResponse httpRequest = (HttpWebResponse)request.GetResponse();

            //mendapatkan aliran data (stream) dari respon server
            Stream dataStream = httpRequest.GetResponseStream();

            //Membaca data dari stream menggunakan StreamReader
            StreamReader reader = new StreamReader(dataStream);

            //Membaca seluruh respon dari server dan menyimpannya sebagai string
            string responseFromServer = reader.ReadToEnd();

            //Mengkonversi string JSON dari respon server menjadi array object University
            University[] universities = Newtonsoft.Json.JsonConvert.DeserializeObject<University[]>(responseFromServer);

            //Menambahkan setiap nama universitas yang didapatkan ke dalam listbox (komponen UI)
            foreach (University university in universities)
            {
                listBox1.Items.Add(university.name);
            }
        }
    }
}