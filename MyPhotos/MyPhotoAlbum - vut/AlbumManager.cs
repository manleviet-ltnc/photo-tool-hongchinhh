﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace Maining.MyPhotoAlbum
{
    public class AlbumManager
    {
        static private string _defaultPath;
        static public string DefaultPath
        {
            get { return _defaultPath; }
            set { _defaultPath = value; }
        }
        static AlbumManager()
        {
            _defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal) +@"\Albums";
            // lay den thu muc my document
        }
        private int _pos = -1;
        public int Index
        {
            get
            {
                int count = Album.Count;
                if (_pos >= count)
                    _pos = count - 1;
                return _pos;
            }
            set
            {
                if (value < 0 || value >= Album.Count)
                    throw new IndexOutOfRangeException(" The given index is out of bounds");
                _pos = value;
            }
        }
        private string _name = string.Empty;
        public string Fullname
        {
            get { return _name; }
            private set { _name = value; }

        }
        public string ShortName
        {
            get
            {
                if (string.IsNullOrEmpty(Fullname))
                    return null;
                else
                    return Path.GetFileNameWithoutExtension(Fullname);
            }
        }

        private PhotoAlbum _album;
        // tao ra quan he ket hop giua manager va photo album
        public PhotoAlbum Album
        {
            get { return _album; }

        }

        public AlbumManager()
        {
            _album = new PhotoAlbum();

        }
        public AlbumManager (string name) : this ()
        {
            _name = name;
            _album = AlbumStorage.ReadAlbum(name);
            if (Album.Count > 0)
                Index = 0;

        }
        public Photograph Current
        {
            get
            {
                if (Index < 0 || Index >= Album.Count)
                    return null;
                return Album[_pos];
            }
        }
        public Bitmap CurrentImage
        {
            get
            {
                if (Current == null)
                    return null;
                return Current.Image;
            }
        }
         static public bool  AlbumExits (string name)
        {
            return File.Exists(name);
        }
        public void Save()
        {
            if (Fullname == null)
                throw new InvalidOperationException("Unable to save albm with no name");
                    AlbumStorage.WriteAlbum(Album, Fullname);
        
        }
        public void Save( string name, bool overwrite)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (name != Fullname && AlbumExits(name) && !overwrite)
                throw new ArgumentException("An album with this name exits");
            AlbumStorage.WriteAlbum(Album, name);
            Fullname = name;

        }
        public bool MoveNext()
        {
            if (Index >= Album.Count)
                return false;
            Index++;
            return true;
        }
        public bool MovePrev()
        {
            if (Index <= 0)
                return false;
            Index--;
            return true;
        }
             
    }
}
