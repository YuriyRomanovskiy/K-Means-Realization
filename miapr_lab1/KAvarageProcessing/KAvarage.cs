using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miapr_lab1
{
    class KAvarage
    {
        public List<ImageClass> classes { get; private set; }
        public List<Image> images { get; private set; }
        //private List<miapr_lab1.Image> centers;
        private List<List<Int32>> vectors;

        private bool isRecalculateNecessary = false;
        private Int32 iterrationCount = 0;
        private Int32 maxIterationCount = 5000;

        public KAvarage(List<miapr_lab1.Image> centers, List<Image> images, List<ImageClass> classes)
        {
            vectors = new List<List<Int32>>();
            //this.centers = centers;
            this.images = images;
            this.classes = classes;
        }

        public void CalculateDistance()
        {
            vectors = new List<List<int>>();
            foreach (ImageClass center in classes)
            {
                
                var tempList = new List<Int32>();
                foreach (Image image in images)
                {
                    if (image == center.Center)
                    {
                        tempList.Add(0);
                    }
                    else
                    {
                        tempList.Add(getVectorLength(center.Center, image));
                    }
                }
                vectors.Add(tempList);
            }
        }
        // first step
        public void DevideByClasses()
        {
            for (int i = 0; i<images.Count; i++)
            {
                Int32 minDistance = Int32.MaxValue;
                Int32 minIndex = 0;
                for (int j = 0; j<classes.Count; j++)
                {
                    if (vectors[j][i]<minDistance)
                    {
                        minDistance = vectors[j][i];
                        minIndex = j;
                    }
                }
                images[i].ImgClass = classes[minIndex];
            }
        }


        public int GetReadyClasses(bool isTrackingCenters = false)
        {
            do
            {
                isRecalculateNecessary = false;
                ClearClassesImageList();
                //AddPointCoClassImageList();
                AddPointCoClassImageList();
                ChangeClassCenters(isTrackingCenters);
                iterrationCount++;
            } while (isRecalculateNecessary && iterrationCount< maxIterationCount);
            return iterrationCount;
        }

        public void ChangeClassCenters(bool isTrackingCenters = false)
        {

            foreach (ImageClass ic in classes)
            {
                Image bestClassCenter = ic.GetBestClassCenter(isTrackingCenters);
                if (bestClassCenter != ic.Center)
                {
                    ic.Center = bestClassCenter;
                    isRecalculateNecessary = true;
                }
            }
        }

        //_________________________________________________________________________________________
        private void ClearClassesImageList()
        {
            foreach(ImageClass ic in classes)
            {
                ic.Images = new List<Image>();
            }
        }

        private void AddPointCoClassImageList()
        {
            CalculateDistance();
            DevideByClasses();
            FullGroups();
        }

        public void FullGroups()
        {
            foreach(ImageClass cl in classes)
            {
                List<Image> temp = new List<Image>();
                foreach(Image img in images)
                {
                    if (img.ImgClass == cl)
                    {
                        temp.Add(img);
                    }
                }
                cl.Images = temp;
            }
        }

        private int getVectorLength(Image center, Image image)
        {
            return Convert.ToInt32(Math.Sqrt(((center.X - image.X) * (center.X - image.X)) + ((center.Y - image.Y) * (center.Y - image.Y))));
        }
    }
}
