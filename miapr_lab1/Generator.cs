using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace miapr_lab1
{
    class Generator
    {
        private Random random;
        
        public int ClassCount { get; set; }
        public int ImagesCount { get; set; }

        public List<ImageClass> classes { get; private set; }
        public List<miapr_lab1.Image> images { get; private set; }
        public List<miapr_lab1.Image> centers { get; private set; }

        private int width;
        private int height;

        public Generator(int maxX= 300, int maxY = 300)
        {
            width = maxX;
            height = maxY;
            ClassCount = 6;
            ImagesCount = 1000;
            random = new Random();
            classes = new List<ImageClass>();
            images = new List<miapr_lab1.Image>();
            centers = new List<Image>();
        }


        public ConcurrentBag<Image> ConvertListToConcurentBag(List<Image> list)
        {
            ConcurrentBag<Image> temp = new ConcurrentBag<Image>();
            foreach(Image image in list)
            {
                temp.Add(image);
            }
            return temp;
        }



        private ImageClass GenerateClass()
        {
            
            return new ImageClass(random.Next(1, 32)*8-1, random.Next(1, 32)*8-1, random.Next(1, 32));
        }

        private void GenerateClasses()
        {
            for (int i = 0; i < ClassCount; i++)
            {
                classes.Add(this.GenerateClass());
            }
        }

        private void  SetCenters()
        {
            for (int i=0; i < ClassCount; i++)
            {
                int index = random.Next(0, images.Count);
                images[index].SetCenter();
                images[index].ImgClass = classes[i];
                centers.Add(images[index]);
                classes[i].Center = images[index];
            }
        }

        private miapr_lab1.Image GenerateImage()
        {
            return new miapr_lab1.Image(random.Next(0, width-3), random.Next(0, height-3));
        }

        private void GenerateImages()
        {
            for(int i= 0; i < ImagesCount; i++)
            {
                images.Add(this.GenerateImage());
            }
            this.SetCenters();
        }

        public void PrepareAll()
        {
            //if(!InputCheck.CompareCountOfVariables(ImagesCount, ClassCount))
            //{
            //    return;
            //}
            this.GenerateClasses();
            this.GenerateImages();
        }

    }
}
