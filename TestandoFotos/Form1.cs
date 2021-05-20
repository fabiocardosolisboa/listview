using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TestandoFotos
{
    public partial class Form1 : Form
    {
        private List<Image> LoadedImages { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //carregando imagens da pasta
            LoadImagesFromFolder();

            //inicializando lista de imagens
            ImageList images = new ImageList();
            images.ImageSize = new Size(130,40);

            foreach(var image in LoadedImages) 
            {
                images.Images.Add(image);
            }

            //configurando nossa listview com imageList
            imageList.LargeImageList = images;

            for(int itemIndex = 1; itemIndex <= LoadedImages.Count; itemIndex++) 
            {
                imageList.Items.Add(new ListViewItem($"Imagem {itemIndex}", itemIndex-1));
            }
        }
        private void LoadImagesFromFolder() 
        {
            LoadedImages = new List<Image>();
            var index = 1;
            while (index < 4) 
            {
                string tempLocation = $@"C:\Users\fabio\Desktop\imagens\{index}.jpg";
                var tempImage = Image.FromFile(tempLocation);
                LoadedImages.Add(tempImage);
                index += 1;
            }
        }

        private void imageList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (imageList.SelectedIndices.Count > 0) 
            {
                var selectedIndex = imageList.SelectedIndices[0];
                Image selectedImg = LoadedImages[selectedIndex];
                selectedImage.Image = selectedImg;
            }
        }
    }
}
