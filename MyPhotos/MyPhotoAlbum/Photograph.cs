using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Maining.MyPhotoAlbum
{
    /// <summary>
    /// The Photograph glass represent a photogaphic 
    /// image store in the file system
    /// </summary>
    
    public class Photograph : IDisposable // hủy đối tượng Photograph
    {
        // biến thành phần dùng để luuw trữ trong một lớp 
        // dấu _ để phân biệt đây là biến thành phàn của lớp
        // private từ khóa truy xuất các thành phần ẩn so với bên ngoài lớp 
        //tính năng bao gói 
        private string _fileName;
        public string FileName
        {
            // sư dung chỉ muốn lấy dl trong filename không cho người lập trình gán dl vào
            get { return this._fileName; }
                               
        }




        private Bitmap _bitmap;

        public Bitmap Image
        {
            get
            {
                if (_bitmap == null)
                    _bitmap = new Bitmap(_fileName);

                //load bức ảnh theo đường dẫn gán vào biến thành phần bit map
                return (_bitmap);
            }
        }
        private string _caption = ""; //gán giá trị ngay sẽ tương đương như câu lệnh gán giá trị bên trong hàm cấu tử
        public string Caption
        {
            get { return _caption; }
            set
            {
                if (_caption != value)
                {
                    _caption = value;
                    HasChanged = true;       
                }
            }
        }
        private string _photrgapher = "";
        
        public string Photogapher
        {
            get { return _photrgapher; }
            set
            {
                if(_photrgapher != value)
                {
                    _photrgapher = value;
                   HasChanged = true;
                  

                }

            }
        }
        private DateTime _dateTaken = DateTime.Now;
        
        public DateTime DateTaken
        {
            get { return _dateTaken; }
             set
            {
                if (_dateTaken != value)
                {
                    _dateTaken = value;
                    HasChanged = true; 
                }
            }


        }


        private string _notes = "";

        public String Notes
        {
            get { return _notes; }
            set
            {
                if (_notes != value)
                {
                    _notes = value;
                    HasChanged = true;
                   
                }
            }
        }
        private bool _haschange = true;
        // chưa đc lưu tren file là true
        public bool HasChanged
        {
            get { return _haschange; } //lấy giá trị của haschange

            set { _haschange = value; } // lấy giá trị của haschange vào    


        }


        public Photograph( string fileName)
        {
            _fileName = fileName;
            _bitmap = null;
            _caption = System.IO.Path.GetFileNameWithoutExtension(FileName);
            // lấy tên file mà không có phần mở rộng
        }
        public override bool Equals(object obj)
        {
            if (obj is Photograph)
            {
                Photograph p = (Photograph)obj;
                return string.Equals(FileName, p.FileName, StringComparison.InvariantCultureIgnoreCase);
                // case chuyển chữ hoa thành chữ thường để kiểm tra 
            }
            return false;
        }
        public override int GetHashCode()
        {
            return FileName.ToLowerInvariant().GetHashCode();
        }
        public override string ToString()
        {
            return FileName;
        }
        public void ReleaseImage()
        {
            if ( _bitmap != null)
            {
                _bitmap.Dispose();
                _bitmap = null;
            }
        }
        public void Dispose()
        {
            ReleaseImage();      
        }
    }
}
