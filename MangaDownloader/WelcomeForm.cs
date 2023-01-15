using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangaDownloader
{
    public partial class SelectMangaForm : Form
    {
        readonly SessionDataContext context;
        public SelectMangaForm(SessionDataContext context)
        {
            InitializeComponent();
            this.context = context;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.context.MangaTitleUrl = this.textBox1.Text;
            this.context.ChapterSelectForm();
        }
    }
}
