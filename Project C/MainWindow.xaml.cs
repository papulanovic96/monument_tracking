using Project_C.Create_monument;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Threading;
using System.Xml.Serialization;

namespace Project_C
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    [Serializable]
    public partial class MainWindow : Window
    {
        
        public static readonly DependencyProperty AllowDraggingProperty;
        public static readonly DependencyProperty AllowDragOutOfViewProperty;
        private ListViewItem listViewItem = new ListViewItem();
        public static List<Spomenik> Elementi
        {
            set;
            get;
        }
        public bool AllowDragging
        {
            get { return true; }
            set { canvas_map.SetValue(AllowDraggingProperty, value); }
        }
        public bool AllowDragOutOfView
        {
            get { return false; }
            set { SetValue(AllowDragOutOfViewProperty, value); }
        }

        private Point startPoint;
        // ListView listView = new ListView();

        public MainWindow()
        {

            InitializeComponent();
            this.DataContext = this;
            Elementi = new List<Spomenik>();
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);





            //Učitavanje tipova iz datoteke
            try // ako postoji xml file probaj ga ucitati
            {
                XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<Tip>));
                using (StreamReader rd = new StreamReader("tipovi.xml"))
                {
                    Tip_spomenika.Tipovi = xs.Deserialize(rd) as ObservableCollection<Tip>;
                }
            }
            catch (FileNotFoundException) //ako ga ne nadjes izbaci gresku
            {
                MessageBox.Show("Nije pronađena datoteka za učitavanje <Tipova>");
                Tip_spomenika.Tipovi = new ObservableCollection<Tip>();
            }
            //Učitavanje etiketa iz fajla

            try // ako postoji xml file probaj ga ucitati
            {
                XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<Etiketa>));
                using (StreamReader rd = new StreamReader("etikete.xml"))
                {
                    Etikete.Etikete_oc = xs.Deserialize(rd) as ObservableCollection<Etiketa>;
                }
            }
            catch (FileNotFoundException) //ako ga ne nadjes izbaci gresku
            {
                MessageBox.Show("Nije pronađena datoteka za učitavanje <Etiketa>.");
                Etikete.Etikete_oc = new ObservableCollection<Etiketa>();
            }

            //spomenici
            try // ako postoji xml file probaj ga ucitati
            {
                XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<Spomenik>));
                using (StreamReader rd = new StreamReader("spomenici.xml"))
                {
                    Create_dialog.Spomen = xs.Deserialize(rd) as ObservableCollection<Spomenik>;
                    listaSpomenika.ItemsSource = Create_dialog.Spomen;
                }
            }
            catch (FileNotFoundException) //ako ga ne nadjes izbaci gresku
            {
                Create_dialog.Spomen = new ObservableCollection<Spomenik>();
                listaSpomenika.ItemsSource = Create_dialog.Spomen;
            }

            /*
            foreach (Spomenik spomenik in Create_dialog.Spomen)
            {
                listaSpomenika.Items.Add(spomenik);
                listaSpomenika.Items.Refresh();
            }*/
            
            try // ako postoji xml file probaj ga ucitati
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<Spomenik>));
                using (StreamReader rd = new StreamReader("SavedCanvas.xml"))
                {
                    Elementi = xs.Deserialize(rd) as List<Spomenik>;
                }
            }
            catch (FileNotFoundException) //ako ga ne nadjes izbaci gresku
            {
                Elementi = new List<Spomenik>();
            }
            foreach (Spomenik spomen in Elementi.ToArray())
            {
                Uri imageUri = new Uri(spomen.Ikonica, UriKind.RelativeOrAbsolute);
                BitmapImage bitmapImage = new BitmapImage(imageUri);
                Image image = new Image();
                image.Source = bitmapImage;
                Image image2 = new Image();
                image2.Source = bitmapImage;
                TextBlock textBlock = new TextBlock();
                textBlock.Tag = spomen.Naziv;
                textBlock.Inlines.Add(image);
                TextBlock tb = new TextBlock();

                tb.Inlines.Add(image2);
                tb.Inlines.Add("\t" + spomen.Naziv);
                tb.Height = 90;

                canvas_map.Children.Add(textBlock);
                textBlock.ToolTip = tb;
                Canvas.SetLeft(textBlock, spomen.X);
                Canvas.SetTop(textBlock, spomen.Y);
            }

        }

        private void myFilter(object sender, FilterEventArgs e)
        {
            var obj = e.Item as Spomenik;

            if (obj != null && search_box.Text.Length > 0)
            {
                if (obj.Naziv.ToLower().Contains(search_box.Text.ToString()))
                    e.Accepted = true;
                else
                    e.Accepted = false;
            }
        }

        ICollectionView filterSpomenikaa;
        
        private void txtPronadjiNaziv_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            if (!DemoOrMain.button_is_clicked)
            {
                var filterSpomenika = new CollectionViewSource() { Source = Create_dialog.Spomen };
                filterSpomenika.Filter += new FilterEventHandler(myFilter);

                filterSpomenikaa = filterSpomenika.View;
                filterSpomenikaa.Refresh();

                listaSpomenika.ItemsSource = filterSpomenikaa;
            }

        }
        private void new_monument(object sender, RoutedEventArgs e)
        {
            var create_dialog = new Create_dialog();
            create_dialog.ShowDialog();
        }
        private void open_help(object sender, RoutedEventArgs e)
        {
            var help_dialog = new Help.Help_dialog();
            help_dialog.ShowDialog();
        }

        private void new_type(object sender, RoutedEventArgs e)
        {
            var type_dialog = new Tip_spomenika();
            type_dialog.ShowDialog();
        }

        private void new_label(object sender, RoutedEventArgs e)
        {
            var label_dialog = new Etikete();
            label_dialog.ShowDialog();
        }

        private void exit_button(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cuvanje_btn_Click(object sender, RoutedEventArgs e)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Spomenik>));
            using (StreamWriter wr = new StreamWriter(@"SavedCanvas.xml"))
            {
                xs.Serialize(wr, Elementi);
            }
            System.Windows.Forms.MessageBox.Show("Elementi su uspješno sačuvani u datoteku <SavedCanvas.xml>.");
        }

        //Drag&Drop
        private void ListView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }
        //DataObject dragData = new DataObject();
        private void ListView_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                // Get the dragged ListViewItem
                listaSpomenika = sender as ListView;
                

                listViewItem = FindAncestor<ListViewItem>((DependencyObject)e.OriginalSource);
                //if (listViewItem.Equals(null)) { return; }
                // Find the data behind the ListViewItem
                Spomenik spomenik = new Spomenik();
                try
                {
                    spomenik = (Spomenik)listaSpomenika.ItemContainerGenerator.
                    ItemFromContainer(listViewItem);
                }
                catch
                {
                    // MessageBox.Show("Pogrešan element za prevlačenje na mapu!", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Error);
                }



                // Initialize the drag & drop operation
                DataObject dragData = new DataObject("nekiFormat", spomenik);
                try
                {
                    DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Move);

                }
                catch
                {
                    //MessageBox.Show("Došlo je do greške", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }

        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }

        private void ListView_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("nekiFormat") || sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }
        public static Spomenik item = new Spomenik();
        private void canvasImage_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("nekiFormat"))
            {
                Point cursorLocation = e.GetPosition(this);
                item = (Spomenik)e.Data.GetData("nekiFormat");

                Uri imageUri = new Uri(item.Ikonica, UriKind.RelativeOrAbsolute);
                BitmapImage bitmapImage = new BitmapImage(imageUri);
                Image image = new Image();
                image.Source = bitmapImage;
                Image image2 = new Image();
                image2.Source = bitmapImage;
                TextBlock textBlock = new TextBlock();
                textBlock.Tag = item.Naziv; 
                textBlock.Inlines.Add(image);
                TextBlock tb = new TextBlock();

                tb.Inlines.Add(image2);
                tb.Inlines.Add("  " + item.Naziv);
                tb.Height = 50;

                bool razliciti = false;

                if (Elementi.Count == 0)
                {
                    razliciti = true;
                } else
                {
                    Rect elemRect = new Rect(new Point(cursorLocation.X - 230, cursorLocation.Y - 140), new Size(55, 55));
                    foreach (Spomenik sp_1 in Elementi)
                    {
                        Rect elemRect_sp_1 = GetRect(sp_1);

                        if (elemRect_sp_1.IntersectsWith(elemRect))
                        {
                            razliciti = false;
                            break;
                        }
                        else
                        {
                            razliciti = true;
                        }
                    }
                }
                if(razliciti)
                {
                    foreach(Spomenik t1b in Elementi)
                    {
                        if (Elementi.Contains(item))
                        {
                            return;
                        }
                    }
                    canvas_map.Children.Add(textBlock);
                    textBlock.ToolTip = tb;
                    Canvas.SetLeft(textBlock, cursorLocation.X - 230);
                    Canvas.SetTop(textBlock, cursorLocation.Y - 140);
                    item.X = cursorLocation.X - 230;
                    item.Y = cursorLocation.Y - 140;
                    Elementi.Add(item);
                    // listaSpomenika.Items.Remove(item);
                    listaSpomenika.Items.Refresh();
                } else
                {
                    foreach (Spomenik t1b in Elementi)
                    {
                        if (Elementi.Contains(item))
                        {
                            return;
                        }
                    }
                    canvas_map.Children.Add(textBlock);
                    textBlock.ToolTip = tb;
                    Canvas.SetLeft(textBlock, cursorLocation.X - 290);
                    Canvas.SetTop(textBlock, cursorLocation.Y - 200);
                    item.X = cursorLocation.X - 290;
                    item.Y = cursorLocation.Y - 200;
                    Elementi.Add(item);
                    listaSpomenika.Items.Refresh();
                }
            }
        }
        private Rect GetRect(Spomenik element)
        {
            return new Rect(new Point(element.X, element.Y), new Size(55, 55));
        }

        private void canvasImage_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("nekiFormat") ||
              sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }


        // Stores a reference to the UIElement currently being dragged by the user.
        private TextBlock elementBeingDragged;

        // Keeps track of where the mouse cursor was when a drag operation began.		
        private Point origCursorLocation;

        // The offsets from the DragCanvas' edges when the drag operation began.
        private double origHorizOffset, origVertOffset;

        // Keeps track of which horizontal and vertical offset should be modified for the drag element.
        private bool modifyLeftOffset, modifyTopOffset;

        // True if a drag operation is underway, else false.
        private bool isDragInProgress;



        public static readonly DependencyProperty CanBeDraggedProperty;

        public static bool GetCanBeDragged(TextBlock uiElement)
        {
            if (uiElement == null)
                return false;
            else
            return true;
        }

        public static void SetCanBeDragged(TextBlock uiElement, bool value)
        {
            if (uiElement != null)
                uiElement.SetValue(CanBeDraggedProperty, value);
        }

        public TextBlock ElementBeingDragged
        {
            get
            {
                if (!this.AllowDragging)
                    return null;
                else
                    return this.elementBeingDragged;
            }
            protected set
            {
                if (this.elementBeingDragged != null)
                    this.elementBeingDragged.ReleaseMouseCapture();

                if (!this.AllowDragging)
                    this.elementBeingDragged = null;
                else
                {
                    if (GetCanBeDragged(value))
                    {
                        this.elementBeingDragged = value;
                        this.elementBeingDragged.CaptureMouse();
                    }
                    else
                        this.elementBeingDragged = null;
                }
            }
        }


        public TextBlock FindCanvasChild(DependencyObject depObj)
        {
            while (depObj != null)
            {
                // Ako je trenutni objekat UIElement koji je child kanvasa izadji i vrati ga
                TextBlock elem = depObj as TextBlock;
                if (elem != null && canvas_map.Children.Contains(elem))
                    break;

                // VisualTreeHelper works with objects of type Visual or Visual3D.
                // If the current object is not derived from Visual or Visual3D,
                // then use the LogicalTreeHelper to find the parent element.
                if (depObj is Visual)
                    depObj = VisualTreeHelper.GetParent(depObj);
                else
                    depObj = LogicalTreeHelper.GetParent(depObj);
            }
            return depObj as TextBlock;
        }

        public static Spomenik dragElem = new Spomenik();
        protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseLeftButtonDown(e);

            this.isDragInProgress = false;

            // Cache the mouse cursor location.
            this.origCursorLocation = e.GetPosition(this);

            // Walk up the visual tree from the element that was clicked, 
            // looking for an element that is a direct child of the Canvas.
            this.ElementBeingDragged = this.FindCanvasChild(e.Source as DependencyObject);
            if (this.ElementBeingDragged == null)
                return;
            if(e.ClickCount == 2)
            {
                var vindov = new Prikaz_spomenika_na_mapi(ElementBeingDragged);
                vindov.Show();
            }

                

            // Get the element's offsets from the four sides of the Canvas.
            double left = Canvas.GetLeft(this.ElementBeingDragged);
            double right = Canvas.GetRight(this.ElementBeingDragged);
            double top = Canvas.GetTop(this.ElementBeingDragged);
            double bottom = Canvas.GetBottom(this.ElementBeingDragged);

            // Calculate the offset deltas and determine for which sides
            // of the Canvas to adjust the offsets.
            this.origHorizOffset = ResolveOffset(left, right, out this.modifyLeftOffset);
            this.origVertOffset = ResolveOffset(top, bottom, out this.modifyTopOffset);

            // Set the Handled flag so that a control being dragged 
            // does not react to the mouse input.
            e.Handled = true;
            
            this.isDragInProgress = true;
        }

        private double cooX, cooY;

        protected override void OnPreviewMouseMove(MouseEventArgs e)
        {
            base.OnPreviewMouseMove(e);

            // If no element is being dragged, there is nothing to do.
            if (this.ElementBeingDragged == null || !this.isDragInProgress)
                return;

            // Get the position of the mouse cursor, relative to the Canvas.
            Point cursorLocation = e.GetPosition(this);

            // These values will store the new offsets of the drag element.
            double newHorizontalOffset, newVerticalOffset;


            // Determine the horizontal offset.
            if (this.modifyLeftOffset)
                newHorizontalOffset = this.origHorizOffset + (cursorLocation.X - this.origCursorLocation.X);
            else
                newHorizontalOffset = this.origHorizOffset - (cursorLocation.X - this.origCursorLocation.X);

            // Determine the vertical offset.
            if (this.modifyTopOffset)
                newVerticalOffset = this.origVertOffset + (cursorLocation.Y - this.origCursorLocation.Y);
            else
                newVerticalOffset = this.origVertOffset - (cursorLocation.Y - this.origCursorLocation.Y);

                Rect elemRect = this.CalculateDragElementRect(newHorizontalOffset, newVerticalOffset);

                bool leftAlign = elemRect.Left < 0;
                bool rightAlign = elemRect.Right > 788;

                if (leftAlign)
                    newHorizontalOffset = modifyLeftOffset ? 0 : 788 - elemRect.Width;
                else if (rightAlign)
                    newHorizontalOffset = modifyLeftOffset ? 788 - elemRect.Width : 0;

                bool topAlign = elemRect.Top < 0;
                bool bottomAlign = elemRect.Bottom > 487;

                if (topAlign)
                    newVerticalOffset = modifyTopOffset ? 0 : 487 - elemRect.Height;
                else if (bottomAlign)
                    newVerticalOffset = modifyTopOffset ? 487 - elemRect.Height : 0;


            if (this.modifyLeftOffset)
                Canvas.SetLeft(this.ElementBeingDragged, newHorizontalOffset);
            else
                Canvas.SetRight(this.ElementBeingDragged, newHorizontalOffset);

            if (this.modifyTopOffset)
                Canvas.SetTop(this.ElementBeingDragged, newVerticalOffset);
            else
                Canvas.SetBottom(this.ElementBeingDragged, newVerticalOffset);
            cooX = newHorizontalOffset;
            cooY = newVerticalOffset;
            item.X = newHorizontalOffset;
            item.Y = newVerticalOffset;

        }

        protected override void OnPreviewMouseUp(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseUp(e);
            Point cursorLocation = e.GetPosition(this);
            try
            {
                Rect ofElementBeingDragged = new Rect(new Point(cooX, cooY), new Size(50, 50));

                foreach (Spomenik dropedOn in Elementi)
                {
                    Rect ofElementBeingDropedOn = GetRect(dropedOn);
                    if (ofElementBeingDragged.Location == ofElementBeingDropedOn.Location)
                    { break; }
                    else
                    {
                        if (ofElementBeingDragged.IntersectsWith(ofElementBeingDropedOn))
                        {

                            Canvas.SetLeft(ElementBeingDragged, dropedOn.X + 50);
                            Canvas.SetTop(ElementBeingDragged, dropedOn.Y + 50);
                            cooX = dropedOn.X + 50;
                            cooY = dropedOn.Y + 50;
                            break;
                        }
                        else
                        {
                            if (isDragInProgress && dropedOn != null)
                            {
                                dropedOn.X = cursorLocation.X - 230;
                                dropedOn.Y = cursorLocation.Y - 140;
                            }
                        }
                    }

                }
            }catch
            {

            }
            
            this.ElementBeingDragged = null;
        }

        private Rect CalculateDragElementRect(double newHorizOffset, double newVertOffset)
        {
            if (this.ElementBeingDragged == null)
            {
                throw new InvalidOperationException("ElementBeingDragged is null.");
            }
            Size elemSize = this.ElementBeingDragged.RenderSize;

            double x, y;

            if (this.modifyLeftOffset)
                x = newHorizOffset;
            else
                x = 788 - newHorizOffset - elemSize.Width;

            if (this.modifyTopOffset)
                y = newVertOffset;
            else
                y = 487 - newVertOffset - elemSize.Height;

            Point elemLoc = new Point(x, y);

            return new Rect(elemLoc, elemSize);
        }

        private static double ResolveOffset(double side1, double side2, out bool useSide1)
        {
            useSide1 = true;
            double result;
            if (Double.IsNaN(side1))
            {
                if (Double.IsNaN(side2))
                {
                    result = 0;
                }
                else
                {
                    result = side2;
                    useSide1 = false;
                }
            }
            else
            {
                result = side1;
            }
            return result;
        }



        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            IInputElement focusedControl = FocusManager.GetFocusedElement(Application.Current.Windows[0]);
            if (focusedControl is DependencyObject)
            {
                string str = Help.HelpDavac.GetHelpKey((DependencyObject)focusedControl);
                Help.HelpDavac.ShowHelp(str, this);
            }
        }

    }
}
