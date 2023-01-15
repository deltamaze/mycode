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
    public partial class ChapterSelect : Form
    {
        readonly SessionDataContext context;
        public ChapterSelect(SessionDataContext context)
        {
            this.context = context;
            InitializeComponent();
            // get url from context

            int getChaptersOffset = 0;
            int getChapterLimit = 96;
            int getChapterTotal = 0; // update after call
            int getChaptersFetched = 0; // increment by limit until > than Total

            // pull manga id 
            string mangaId = 
            // call api, and pull all chapters, this may require walking thourgh a few times to build list
            // once done present list in form
            // if error, write to log
        }
    }
}
