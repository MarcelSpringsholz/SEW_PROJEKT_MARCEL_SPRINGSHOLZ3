using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace CarTuningProjekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Projekt
        public int Pferdestärke { get; set; }
        public List<string> Modifikationen { get; set; }
        public string Marke { get; set; }
        public bool Bmwm4 { get; set; }
        public bool KTMDUKE { get; set; }
        public List<string> Bilder { get; set; }
        private BMWM4 bmwm4save;
        private KTMDUKE ktmduke125save;
        bool ausgewaelt = false;
        int i = 1;
        public ObservableCollection<string> ModifikationenOut = new ObservableCollection<string>();
        public MainWindow()
        {
            InitializeComponent();
            ListBox.ItemsSource = ModifikationenOut;
            string[] Bilder = new string[3];
        }
        private void Button_Click_Konfiguration(object sender, RoutedEventArgs e)
        {
            MyStack<int> stack = new MyStack<int>();
            stack.push(i);
            i++;
            //Alles Neustarten
            Bmwm4 = false;
            PSStandardBMWM4.IsChecked = true;
            AuspuffStandardBMWM4.IsChecked = true;
            LackRotBMWM4.IsChecked = true;
            FelgenStandardBMWM4.IsChecked = true;
            PSStandardKTMDUKE.IsChecked = true;
            AuspuffStandardKTMDUKE.IsChecked = true;
            AussehenStandardKTMDUKE.IsChecked = true;
            KennzeichenLangKTMDUKE.IsChecked = true;
            Modifikationen = new List<string>();
            Modifikationen.Clear();
            KTMDUKEKonfi.Visibility = Visibility.Collapsed;
            BMWM4Konfi.Visibility = Visibility.Collapsed;
            Auswahl.Visibility = Visibility.Visible;
            //Mit dem IMG TAG anschauen C:\Users\Marcel Springsholz\Desktop\SEW\CarTuningProjekt\BilderCartuning\KTMDUKE1FrontOriginal.png
            ausgewaelt = false;
            Img.Source = new BitmapImage(new Uri(@"../", UriKind.Relative));
            ModifikationenOut.Clear();
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            //Daten speichern
            if (ausgewaelt)
            {
                if (Bmwm4 == true)
                {
                    bmwm4save = new BMWM4(Pferdestärke, Modifikationen, Marke);
                    System.IO.File.WriteAllText(@"..\..\..\KonfigurationBMWm4.txt", bmwm4save.ToString());
                }
                else
                {
                    ktmduke125save = new KTMDUKE(Pferdestärke, Modifikationen, Marke);
                    System.IO.File.WriteAllText(@"..\..\..\KonfigurationKTMduke.txt", ktmduke125save.ToString());
                }
            }
            else
                throw new Exception("Kein Element ausgewählt!");
        }
        private void Button_Click_Load(object sender, RoutedEventArgs e)
        {
            if (Bmwm4 == true)
            {
                string alles = System.IO.File.ReadAllText(@"..\..\..\KonfigurationBMWm4.txt");
                int Pferdestärken = Convert.ToInt32(alles.Split(';')[0]);
                List<string> Modifikationen = ((alles.Split(';')[1]).Split(',')).ToList<string>(); 
                string Marke = alles.Split(';')[2];
                bmwm4save = new BMWM4(Pferdestärke, Modifikationen, Marke);
                if (bmwm4save.Pferdestärke == 431)
                {
                    PSStandardBMWM4.IsChecked = true;
                }
                else
                    PSLeistungssteigBMWM4.IsChecked = true;
                if (bmwm4save.Modifikationen[0] == "Auspuff: Akrapovic")
                {
                    AuspuffAkrapovicBMWM4.IsChecked = true;
                }
                else
                {
                    AuspuffStandardBMWM4.IsChecked = true;
                }
                if (bmwm4save.Modifikationen[1] == "Lack: Rot")
                {
                    LackRotBMWM4.IsChecked = true;
                }
                else if (bmwm4save.Modifikationen[1] == "Lack: Goldgelb")
                {
                    LackGelbBMWM4.IsChecked = true;
                }
                else
                {
                    LackBlauBMWM4.IsChecked = true;
                }
                if (bmwm4save.Modifikationen[2] == "Felgen: Standard")
                {
                    FelgenStandardBMWM4.IsChecked = true;
                }
                else
                {
                    FelgenSportBMWM4.IsChecked = true;
                }
            }
            else
            {
                string alles = System.IO.File.ReadAllText(@"..\..\..\KonfigurationKTMduke.txt");
                int Pferdestärken = Convert.ToInt32(alles.Split(';')[0]);
                List<string> Modifikationen = ((alles.Split(';')[1]).Split(',')).ToList<string>();
                string Marke = alles.Split(';')[2];
                ktmduke125save = new KTMDUKE(Pferdestärke, Modifikationen, Marke);
                if (ktmduke125save.Pferdestärke == 15)
                {
                    PSStandardKTMDUKE.IsChecked = true;
                }
                else
                    PS50KTMDUKE.IsChecked = true;

                if (ktmduke125save.Modifikationen[0] == "Auspuff: Standard")
                {
                    AuspuffStandardKTMDUKE.IsChecked = true;
                }
                else if (ktmduke125save.Modifikationen[0] == "Auspuff: Akrapovic")
                {
                    AuspuffAkrapovicKTMDUKE.IsChecked = true;
                }
                else
                {
                    AuspuffLeoVinceKTMDUKE.IsChecked = true;
                }
                if (ktmduke125save.Modifikationen[1] == "Aussehen: Orange")
                {
                    AussehenStandardKTMDUKE.IsChecked = true;
                }
                else if (ktmduke125save.Modifikationen[1] == "Aussehen: Grün")
                {
                    AussehenGrünKTMDUKE.IsChecked = true;
                }
                else if (ktmduke125save.Modifikationen[1] == "Aussehen: Folie 1")
                {
                    AussehenF1KTMDUKE.IsChecked = true;
                }
                else
                {
                    AussehenF2KTMDUKE.IsChecked = true;
                }
                if (ktmduke125save.Modifikationen[2] == "Kennzeichen: Kurz")
                {
                    KennzeichenKurzKTMDUKE.IsChecked = true;
                }
                else
                {
                    KennzeichenLangKTMDUKE.IsChecked = true;
                }
            }
            Bild();
            }
        private void Button_Click_BMWM4(object sender, RoutedEventArgs e)
        {
            Auswahl.Visibility = Visibility.Collapsed;
            BMWM4Konfi.Visibility = Visibility.Visible;
            Bmwm4 = true;
        }
        public void KonfigBMWM4()
        {
            Modifikationen = new List<string>();
            Marke = "BMW";
            if (PSStandardBMWM4.IsChecked == true)
            {
                Pferdestärke = 431;
            }
            else
                Pferdestärke = 531;

            if (AuspuffStandardBMWM4.IsChecked == true)
            {
                Modifikationen.Add("Auspuff: Standard");
            }
            else
            {
                Modifikationen.Add("Auspuff: Akrapovic");
            }
            if (LackRotBMWM4.IsChecked == true)
            {
                Modifikationen.Add("Lack: Rot");
            }
            else if (LackGelbBMWM4.IsChecked == true)
            {
                Modifikationen.Add("Lack: Goldgelb");
            }
            else
            {
                Modifikationen.Add("Lack: Blau");
            }
            if (FelgenStandardBMWM4.IsChecked == true)
            {
                Modifikationen.Add("Felgen: Standard");
            }
            else
            {
                Modifikationen.Add("Felgen: M-Sport");
            }
        }
        public void Bild()
        {
            //BMW m4 bild auswahl
            Bilder = new List<string>();

            if (Bmwm4)
            {
                if (Modifikationen[0] == "Auspuff: Standard")
                {
                    if (Modifikationen[1] == "Lack: Rot")
                    {
                        if (Modifikationen[2] == "Felgen: Standard")
                        {
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\BMWM4RedFront.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\BMWM4RedBack.png");
                        }
                        else
                        {
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\BMWM4RedFrontF2.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\BMWM4RedBackF2.png");
                        }
                    }
                    else if(Modifikationen[1] == "Lack: Goldgelb")
                    {
                        if (Modifikationen[2] == "Felgen: Standard")
                        {
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\BMWM4YellowFront.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\BMWM4YellowBack.png");
                        }
                        else
                        {
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\BMWM4YellowFrontF2.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\BMWM4YellowBackF2.png");
                        }
                    }
                    else
                    {
                        if (Modifikationen[2] == "Felgen: Standard")
                        {
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\BMWM4BlueFront.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\BMWM4BlueBack.png");
                        }
                        else
                        {
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\BMWM4BlueFrontF2.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\BMWM4BlueBackF2.png");
                        }
                    }
                }
                else
                {
                    if (Modifikationen[1] == "Lack: Rot")
                    {
                        if (Modifikationen[2] == "Felgen: Standard")
                        {
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\BMWM4RedFront.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\BMWM4RedBack.png");
                        }
                        else
                        {
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\BMWM4RedFrontF2.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\BMWM4RedBackF2.png");
                        }
                    }
                    else if (Modifikationen[1] == "Lack: Goldgelb")
                    {
                        if (Modifikationen[2] == "Felgen: Standard")
                        {
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\BMWM4YellowFront.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\BMWM4YellowBack.png");
                        }
                        else
                        {
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\BMWM4YellowFrontF2.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\BMWM4YellowBackF2.png");
                        }
                    }
                    else
                    {
                        if (Modifikationen[2] == "Felgen: Standard")
                        {
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\BMWM4BlueFront.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\BMWM4BlueBack.png");
                        }
                        else
                        {
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\BMWM4BlueFrontF2.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\BMWM4BlueBackF2.png");
                        }
                    }
                }
            }
            //KTM Duke bild auswahl
            else
            {
                if (Modifikationen[0] == "Auspuff: Standard")
                {
                    if (Modifikationen[1] == "Aussehen: Orange")
                    {
                        if (Modifikationen[2] == "Kennzeichen: Kurz")
                        {
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1SideOriginalKurz.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1FrontOriginalKurz.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1BackOriginalKurz.png");
                        }
                        else
                        {
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1SideOriginal.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1FrontOriginal.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1BackOriginal.png");
                        }
                    }
                    else if (Modifikationen[1] == "Aussehen: Grün")
                    {
                        if (Modifikationen[2] == "Kennzeichen: Kurz")
                        {
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1SideOriginalGreenKurz.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1FrontOriginalGreenKurz.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1BackOriginalGreenKurz.png");
                        }
                        else
                        {
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1SideOriginalGreen.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1FrontOriginalGreen.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1BackOriginalGreen.png");
                        }
                    }
                    else if (Modifikationen[1] ==  "Aussehen: Folie 1")
                    {
                        if (Modifikationen[2] == "Kennzeichen: Kurz")
                        {
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1SideOriginalG1Kurz.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1FrontOriginalG1Kurz.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1BackOriginalG1Kurz.png");
                        }
                        else
                        {
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1SideOriginalG1.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1FrontOriginalG1.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1BackOriginalG1.png");
                        }
                    }
                    else
                    {
                        if (Modifikationen[2] == "Kennzeichen: Kurz")
                        {
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1SideOriginalG2Kurz.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1FrontOriginalG2Kurz.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1BackOriginalG2Kurz.png");
                        }
                        else
                        {
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1SideOriginalG2.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1FrontOriginalG2.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1BackOriginalG2.png");
                        }
                    }
                }
                else if (Modifikationen[0] == "Auspuff: Akrapovic")
                {
                    if (Modifikationen[1] == "Aussehen: Orange")
                    {
                        if (Modifikationen[2] == "Kennzeichen: Kurz")
                        {
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1SideAkraKurz.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1FrontAkraKurz.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1BackAkraKurz.png");
                        }
                        else
                        {
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1SideAkra.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1FrontAkra.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1BackAkra.png");
                        }
                    }
                    else if (Modifikationen[1] == "Aussehen: Grün")
                    {
                        if (Modifikationen[2] == "Kennzeichen: Kurz")
                        {
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1SideAkraGreenKurz.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1FrontAkraGreenKurz.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1BackAkraGreenKurz.png");
                        }
                        else
                        {
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1SideAkraGreen.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1FrontAkraGreen.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1BackAkraGreen.png");
                        }
                    }
                    else if (Modifikationen[1] == "Aussehen: Folie 1")
                    {
                        if (Modifikationen[2] == "Kennzeichen: Kurz")
                        {
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1SideAkraG1Kurz.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1FrontAkraG1Kurz.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1BackAkraG1Kurz.png");
                        }
                        else
                        {
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1SideAkraG1.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1FrontAkraG1.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1BackAkraG1.png");
                        }
                    }
                    else
                    {
                        if (Modifikationen[2] == "Kennzeichen: Kurz")
                        {
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1SideAkraG2Kurz.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1FrontAkraG2Kurz.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1BackAkraG2Kurz.png");
                        }
                        else
                        {
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1SideAkraG2.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1FrontAkraG2.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1BackAkraG2.png");
                        }
                    }
                }
                else
                {
                    if (Modifikationen[1] == "Aussehen: Orange")
                    {
                        if (Modifikationen[2] == "Kennzeichen: Kurz")
                        {
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1SideLeoKurz.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1FrontLeoKurz.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1BackLeoKurz.png");
                        }
                        else
                        {
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1SideLeo.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1FrontLeo.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1BackLeo.png");
                        }
                    }
                    else if (Modifikationen[1] == "Aussehen: Grün")
                    {
                        if (Modifikationen[2] == "Kennzeichen: Kurz")
                        {
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1SideLeoGreenKurz.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1FrontLeoGreenKurz.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1BackLeoGreenKurz.png");
                        }
                        else
                        {
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1SideLeoGreen.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1FrontLeoGreen.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1BackLeoGreen.png");
                        }
                    }
                    else if (Modifikationen[1] == "Aussehen: Folie 1")
                    {
                        if (Modifikationen[2] == "Kennzeichen: Kurz")
                        {
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1SideLeoG1Kurz.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1FrontLeoG1Kurz.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1BackLeoG1Kurz.png");
                        }
                        else
                        {
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1SideLeoG1.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1FrontLeoG1.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1BackLeoG1.png");
                        }
                    }
                    else
                    {
                        if (Modifikationen[2] == "Kennzeichen: Kurz")
                        {
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1SideLeoG2Kurz.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1FrontLeoG2Kurz.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1BackLeoG2Kurz.png");
                        }
                        else
                        {
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1SideLeoG2.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1FrontLeoG2.png");
                            Bilder.Add(@"D:\Benutzer\Marcel\Desktop\CarTuning-Projekt2\BilderCartuning\KTMDUKE1BackLeoG2.png");
                        }
                    }
                }
            }
        }
        private void Button_Click_KTMDUKE(object sender, RoutedEventArgs e)
        {
            Auswahl.Visibility = Visibility.Collapsed;
            KTMDUKEKonfi.Visibility = Visibility.Visible;
            KTMDUKE = true;
        }
        public void KonfigKTMDUKE()
        {
            Modifikationen = new List<string>();
            Marke = "KTM";
            if (PSStandardKTMDUKE.IsChecked == true)
            {
                Pferdestärke = 15;
            }
            else
                Pferdestärke = 50;

            if (AuspuffStandardKTMDUKE.IsChecked == true)
            {
                Modifikationen.Add("Auspuff: Standard");
            }
            else if(AuspuffAkrapovicKTMDUKE.IsChecked == true)
            {
                Modifikationen.Add("Auspuff: Akrapovic");
            }
            else
            {
                Modifikationen.Add("Auspuff: Leo Vince");
            }
            if (AussehenStandardKTMDUKE.IsChecked == true)
            {
                Modifikationen.Add("Aussehen: Orange");
            }
            else if (AussehenGrünKTMDUKE.IsChecked == true)
            {
                Modifikationen.Add("Aussehen: Grün");
            }
            else if(AussehenF1KTMDUKE.IsChecked == true)
            {
                Modifikationen.Add("Aussehen: Folie 1");
            }
            else
            {
                Modifikationen.Add("Aussehen: Folie 2");
            }
            if (KennzeichenKurzKTMDUKE.IsChecked == true)
            {
                Modifikationen.Add("Kennzeichen: Kurz");
            }
            else
            {
                Modifikationen.Add("Kennzeichen: Lang");
            }
        }
        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            if (Bmwm4 || KTMDUKE)
            {
                for (int i = Bilder.Count; i >= 0; i--)
                {
                    if (i == Bilder.Count)
                    {
                        if (Img.Source.ToString().Replace("file:///", "").Replace("/", "\\") == Bilder[0])
                        {
                            Img.Source = new BitmapImage(new Uri(Bilder[--i]));
                        }
                    }
                    else
                    {
                        if (Img.Source.ToString().Replace("file:///", "").Replace("/", "\\") == Bilder[i])
                        {
                            Img.Source = new BitmapImage(new Uri(Bilder[--i]));
                        }
                    }
                    
                }
            }
        }
        private void Button_Click_Next(object sender, RoutedEventArgs e)
        {
            if (Bmwm4||KTMDUKE)
            {
                for (int i = 0; i < Bilder.Count; i++)
                {
                    if (i == Bilder.Count-1)
                    {
                        if (Img.Source.ToString().Replace("file:///", "").Replace("/", "\\") == Bilder[i])
                        {
                            Img.Source = new BitmapImage(new Uri(Bilder[0]));
                        }
                    }
                    else
                    {
                        if (Img.Source.ToString().Replace("file:///", "").Replace("/", "\\") == Bilder[i])
                        {
                            Img.Source = new BitmapImage(new Uri(Bilder[++i]));
                        }
                    }
                }
            }
        }
        private void Checked(object sender, RoutedEventArgs e)
        {
            
            if (Bmwm4)
            {
                ausgewaelt = true;
                KonfigBMWM4();
                Bild();
                string s = "";
                for (int i = 0; i < Modifikationen.Count; i++)
                {
                    s += Modifikationen[i]+", ";
                }
                ModifikationenOut.Clear();
                ModifikationenOut.Add(s);
                Img.Source = new BitmapImage(new Uri(Bilder[0]));
            }
            else if(KTMDUKE)
            {
                ausgewaelt = true;
                KonfigKTMDUKE();
                Bild();
                string s = "";
                for (int i = 0; i < Modifikationen.Count; i++)
                {
                    s += Modifikationen[i] + ", ";
                }
                ModifikationenOut.Clear();
                ModifikationenOut.Add(s);
                Img.Source = new BitmapImage(new Uri(Bilder[0]));
            }
            else
            {

            }
            
        }
    }
}
