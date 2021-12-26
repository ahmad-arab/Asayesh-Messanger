using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Asayesh_Messanger
{
    public class WindowViewModel: BaseViewModel
    {
        #region Private members
        /// <summary>
        /// The window this view model controls
        /// </summary>
        private Window mWindow;

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        private int mOuterMarginSize = 10;
        private int mWindowRadius = 10;
        #endregion

        #region Public properties

        public double WindowMinWidth { get; set; } = 400;
        public double WindowMinHeight { get; set; } = 400;

        public int BorderThickness { get; set; } = 6;
        public Thickness ResizeBorderThickness { get { return new Thickness(BorderThickness+ mOuterMarginSize); }}
        public Thickness InnerContentPadding { get { return new Thickness(BorderThickness); } }

        public int OuterMarginSize
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mOuterMarginSize;
            }
            set
            {
                mOuterMarginSize = value;
            }
        }
        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }
        public int WindowRadius
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mWindowRadius;
            }
            set
            {
                mWindowRadius = value;
            }
        }
        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

        public int TitleHeight { get; set; } = 42;
        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight+ BorderThickness); } }

        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Chat;

        #endregion

        #region Commands
        public ICommand MinimizeCommand { get; set; }
        public ICommand MaximizeCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand MenuCommand { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="window"></param>
        public WindowViewModel(Window window)
        {
            mWindow = window;
            mWindow.StateChanged += (sender, e) =>
             {
                 OnPropertyChanged(nameof(ResizeBorderThickness));
                 OnPropertyChanged(nameof(OuterMarginSize));
                 OnPropertyChanged(nameof(OuterMarginSizeThickness));
                 OnPropertyChanged(nameof(WindowRadius));
                 OnPropertyChanged(nameof(WindowCornerRadius));
             };

            MinimizeCommand = new RelayCommand((object v) => mWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand((object v) => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand((object v) => mWindow.Close());
            MenuCommand = new RelayCommand((object v) => SystemCommands.ShowSystemMenu(mWindow,
                new Point( Mouse.GetPosition(mWindow).X+mWindow.Left,Mouse.GetPosition(mWindow).Y+mWindow.Top) ));

            var resizer = new WindowResizer(mWindow);
        }
        #endregion
    }
}
