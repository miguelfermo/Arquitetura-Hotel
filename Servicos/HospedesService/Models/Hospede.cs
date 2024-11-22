public class Hospede
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public bool Vip { get; set; }
    public List<int> Reservas { get; set; } = new List<int>();
}
