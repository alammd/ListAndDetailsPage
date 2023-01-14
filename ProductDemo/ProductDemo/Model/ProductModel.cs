using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ProductDemo.Model
{
    public class ProductModel : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Brand { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Rating { get; set; }
        public string SellerAdvice { get; set; }

        private double rotationY;

        public double RotationY
        {
            get { return rotationY; }
            set 
            {
                rotationY = value;
                NotifyPropertyChanged(nameof(RotationY));
            }
        }

        public List<Feedback> Feedback { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
    public class Feedback
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Review { get; set; }
        public string FullReview { get; set; }
    }
}
