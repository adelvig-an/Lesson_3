using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_3.VM
{
    public class MainVM : ViewModelBase
    {
        private PageVM currentPage;
        public PageVM CurrentPage
        {
            get => currentPage;
            set => SetProperty(ref currentPage, value);
        }

        public MainVM()
        {
            CurrentPage = new StudentPageVM();
        }
    }
}
