
using DataBinding.coleccion.views;
using System.Collections.ObjectModel;
namespace Databinding.Coleccion.Views;

public partial class MainPage : ContentPage
{

    public ObservableCollection<OrigenDePaquete> Origenes { get; }
    private OrigenDePaquete? _origenSeleccionado = null;
    private string? _nombreDelOrigen = string.Empty;
    private string? _rutaDelOrigen = string.Empty;

    public OrigenDePaquete OrigenSeleccionado
    {
        get => _origenSeleccionado;
        set
        {
            if (_origenSeleccionado != value)
            {
                _origenSeleccionado = value;
                OnPropertyChanged(nameof(OrigenSeleccionado));
            }
        }
    }
    public MainPage()
    {
        InitializeComponent();


        OrigenDePaquete? origenSeleccionado = null;

        Origenes = new ObservableCollection<OrigenDePaquete>();
        CargarDatos();
        BindingContext = this;
        OrigenesListView.ItemsSource = Origenes;
        if (Origenes.Count > 0)
        {
            OrigenSeleccionado = Origenes[0];
        }
        //OrigenesListView.ItemsSource =_origenes;
        //OrigenesListView.SelectedItem = origenSeleccionado;


    }


    private void CargarDatos()
    {
        Origenes.Add(new OrigenDePaquete
        {
            Nombre = "nuget.org",
            Origen = "https://api.nuget.org/v3/index.json",
            EstadoHabilitado = true,
        });
        Origenes.Add(new OrigenDePaquete
        {
            Nombre = "Microsoft Visual Studio Offline Packages",
            Origen = @"C:\Program Filers (x86)\Microsoft SDKs \NugetPackagges",
            EstadoHabilitado = false,
        });
    }

    public string NombreDelOrigen
    {
        get => _nombreDelOrigen;
        set
        {
            if (_nombreDelOrigen != value)
            {
                _nombreDelOrigen = value;
                OnPropertyChanged(nameof(NombreDelOrigen));
            }
        }
    }


    public string RutaDelOrigen
    {
        get => _rutaDelOrigen;
        set
        {
            if (_rutaDelOrigen != value)
            {
                _rutaDelOrigen = value;
                OnPropertyChanged(nameof(RutaDelOrigen));
            }
        }
    }
    private void Button_Clicked(object sender, EventArgs e)
    {


        var origen = new OrigenDePaquete
        {
            Nombre = "origen del paquete",
            Origen = "URL o ruta del origen del paquete",
            EstadoHabilitado = false,
        };
        Origenes.Add(origen);
        OrigenSeleccionado = origen;

    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {


        //OrigenDePaquete seleccionado = (OrigenDePaquete)
        //    OrigenesListView.SelectedItem;

        if (OrigenSeleccionado != null)
        {
            var indice = Origenes.IndexOf(OrigenSeleccionado);

            OrigenDePaquete? nuevoSelecionado;
            if (Origenes.Count > 1)
            {//hay mas de un elemento

                if (indice < Origenes.Count - 1)
                {
                    // El elemento selecionado no es el ultimo
                    nuevoSelecionado = Origenes[indice + 1];

                }
                else
                {
                    //ultimo
                    nuevoSelecionado = Origenes[indice - 1];
                }
            }
            else
            {
                //solo hay un elemento
                nuevoSelecionado = null;
            }
            Origenes.Remove(OrigenSeleccionado);
            OrigenSeleccionado = nuevoSelecionado;
            //_origenes.Remove(seleccionado);
            //OrigenesListView.ItemsSource = null;
            //OrigenesListView.ItemsSource = _origenes;
            //OrigenesListView.SelectedItem = nuevoSelecionado; 
        }

    }

    private void OrigenesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {




        if (OrigenSeleccionado != null)
        {
            NombreDelOrigen = OrigenSeleccionado.Nombre;
            RutaDelOrigen = OrigenSeleccionado.Origen;
        }
        else
        {
            NombreDelOrigen = string.Empty;
            RutaDelOrigen = string.Empty;
        }
    }

    private void OnActualizarbutton(object sender, EventArgs e)
    {
        if (OrigenSeleccionado != null)
        {
            OrigenSeleccionado.Nombre = NombreDelOrigen;
            OrigenSeleccionado.Origen = RutaDelOrigen;

        }

    }
}