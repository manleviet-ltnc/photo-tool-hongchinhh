using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Maining.MyPhotoAlbum;
namespace Maining.MyPhotoControls
{
    public partial class PhotoEditDialog : Maining.MyPhotoControls.BaseEditDialog
    {
        private Photograph _photo;
        private Photograph Photo
        {
            get { return _photo; }
        }

        private AlbumManager _manager = null;
        private AlbumManager Manager
        {
            get { return _manager; }
        }


          protected PhotoEditDialog()
        {
            InitializeComponent();
        }
        public PhotoEditDialog (Photograph photo) : this()
        {
            if (photo == null)
                throw new ArgumentNullException("The photo parameter cannot be null");
                   
                    InitializeDialog(photo);
        }
        public PhotoEditDialog(AlbumManager mgr) : this()
        {
            if (mgr == null)
                throw new ArgumentNullException("The mrg parameter cannnot be null ");

            _manager = mgr;
            InitializeDialog(mgr.Current);

        }

    private void InitializeDialog(Photograph photo)
        {
            _photo = photo;
            ResetDialog();  
        }
        protected override void ResetDialog()
        {
            Photograph photo = Photo;
            if(photo == null)
            {
                txtPhotoFile.Text = photo.FileName;
                txtCaption.Text = photo.Caption;
                txtDateTaken.Text = photo.DateTaken.ToString();
                txtPhotographer.Text = photo.Photographer;
                txtNotes.Text = photo.Notes;

            }
           
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
                SaveSettings();

        }
        protected void SaveSettings ()
        {
            Photograph photo = Photo;
            if(photo != null)
            {
                photo.Caption = txtCaption.Text;
                photo.Photographer = txtPhotographer.Text;
                photo.Notes = txtNotes.Text;
             try
                {
                    photo.DateTaken = DateTime.Parse(txtDateTaken.Text);
                }
                catch(FormatException) { }
            }
        }

        private void txtCaption_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
