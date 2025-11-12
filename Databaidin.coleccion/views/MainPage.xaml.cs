using Databaidin.coleccion.models;
using Databaidin.coleccion.models;



namespace DataBinding.coleccion.Views;

public partial class MainPage : ContentPage
{
    private IList<OrigenDePaquete> _origenes;
    public MainPage()
    {
        InitializeComponent();
        _origenes = new List<OrigenDePaquete>();
        CargarDatos();
        OrigenesListView.ItemsSource = _origenes;
        if (_origenes.Count > 0)
        {
            OrigenesListView.SelectedItem = _origenes[0];
        }
    }

    private void CargarDatos()
    {
        _origenes.Add(new OrigenDePaquete()
        {
            Nombre = "nuget.org",
            Origen = "https://api.nuget.org/v3/index.json",
            EstaHabilitado = false,
        });

        _origenes.Add(new OrigenDePaquete()
        {
            Nombre = "Microsoft Visual Studio OFFline Packges",
            Origen = @"C:\Program Files(x86)\Microsoft SDKs\NuGetPackges",
            EstaHabilitado = false,
        });
    }

    private void OnAgregarButtonCliked(object sender, EventArgs e)
    {
        var origen = new OrigenDePaquete

        {
            Nombre = "Origen del paquete",
            Origen = "URL o ruta del origen del paquete",
            EstaHabilitado = false,
        };
        _origenes.Add(origen);
        OrigenesListView.ItemsSource = null;
        OrigenesListView.ItemsSource = _origenes;
        OrigenesListView.SelectedItem = origen;
    }

    private void OnDeLeteButtonClicked(object sender, EventArgs e)
    {
        OrigenDePaquete seleccionado =
            (OrigenDePaquete)OrigenesListView.SelectedItem;

        if (seleccionado != null)
        {
            var indice = _origenes.IndexOf(seleccionado);
            OrigenDePaquete? nuevoSeleccionado;
            if (_origenes.Count > 1)
            {
                //Hay más de un elemento 
                if (indice < _origenes.Count - 1)
                {
                    //El elemento seleccionado no es el último 
                    nuevoSeleccionado = _origenes[indice + 1];
                }
                else
                {
                    //El elemento seleccionado es el último
                    nuevoSeleccionado = _origenes[indice - 1];
                }
            }
            else
            {
                // Sólo hay un elemento
                nuevoSeleccionado = null;
            }
            _origenes.Remove(seleccionado);
            OrigenesListView.ItemsSource = null;
            OrigenesListView.ItemsSource = _origenes;
            OrigenesListView.SelectedItem = nuevoSeleccionado;
        }

    }

    private void OrigenesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        OrigenDePaquete origenSeleccionado =
            (OrigenDePaquete)OrigenesListView.SelectedItem;
        if (origenSeleccionado != null)
        {
            NombreEntry.Text = origenSeleccionado.Nombre;
            OrigenEntry.Text = origenSeleccionado.Origen;
        }

        else
        {
            NombreEntry.Text = string.Empty;
            OrigenEntry.Text = string.Empty;
        }

    }

    private void OnActualizarButton_Cliked(object sender, EventArgs e)
    {
        OrigenDePaquete? origenSeleccionado =
            OrigenesListView.SelectedItem as OrigenDePaquete;
        if (origenSeleccionado != null)
        {
            origenSeleccionado.Nombre = NombreEntry.Text;
            origenSeleccionado.Origen = OrigenEntry.Text;
            OrigenesListView.ItemsSource = null;
            OrigenesListView.ItemsSource = _origenes;
            OrigenesListView.SelectedItem = origenSeleccionado;

        }
    }
}