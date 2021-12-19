namespace WpfApp.Views
{
    public interface IRandomDialog
    {
        public int? Result { get; set; }
        public bool? ShowDialog();
    }
}
