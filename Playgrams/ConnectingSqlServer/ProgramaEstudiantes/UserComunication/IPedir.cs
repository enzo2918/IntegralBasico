namespace ProgramaEstudiantes
{
    public interface IPedir
    {
        string Cadena(string mensaje);
        int Entero(string mensaje, (int, int) rangoValido);
    }
}