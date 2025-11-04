namespace DataBinding.Data
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            contador = new Contador();
            BindingContext = contador;
            //ConteoLabel.Text = contador.Conteo.ToString();
        }

        private void OnContarButtonClicked(object sender, EventArgs e)
        {
            contador.Contar();
            //ConteoLabel.Text = contador.Conteo.ToString();
        }

        private void OnReiniciarButtonClicked(object sender, EventArgs e)
        {
            contador.Reiniciar();
            //ConteoLabel.Text = contador.Conteo.ToString();
        }

    }
}
