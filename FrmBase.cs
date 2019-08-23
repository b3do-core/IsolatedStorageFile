using System;
using System.Windows.Forms;
using System.IO.IsolatedStorage;
using System.Reflection;

namespace IsolatedStor
{
    public partial class FrmBase : Form
    {
        #region todo: methods

        private IsolatedStorageFile IsolatedStorageHelper()
        {
            // Retrieve an IsolatedStorageFile for the current Domain and Assembly.
            IsolatedStorageFile isoFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.User |
                IsolatedStorageScope.Assembly |
                IsolatedStorageScope.Domain,
                null,
                null);

            return isoFile;
        }

        #endregion

        public FrmBase()
        {
            InitializeComponent();
            this.Text = "IsolatedStorageFile";
        }

        private void BtnGet_Click(object sender, EventArgs e)
        {
            IsolatedStorageFile isoStore = IsolatedStorageHelper();

            if (isoStore != null)
            {
                PropertyInfo propertyinfo = isoStore.GetType().GetProperty("RootDirectory", BindingFlags.Instance | BindingFlags.NonPublic);
                string isoStorepath = propertyinfo.GetValue(isoStore, null).ToString();
                //string pathpdf = isoStorepath + filenamepdf;

                TxtIsolatedStorage.ResetText();
                TxtIsolatedStorage.Text = isoStorepath + "\r\n======";
            }
            else
            {
                TxtIsolatedStorage.ResetText();
                TxtIsolatedStorage.Text = "\r\nIsolatedStorageFile is null.";
            }
        }
    }
}
