namespace DESAFIOPROJETOHOSPEDAGEM.Models;

public class Reserva
{
    public List<Pessoa> Hospedes { get; set; }
    public Suite Suite { get; set; }
    public int DiasReservados { get; set; }

    public Reserva() { }

    public Reserva(int diasReservados)
    {
        DiasReservados = diasReservados;
    }

    public void CadastrarHospedes(List<Pessoa> hospedes)
    {
        if (hospedes.Count <= Suite.Capacidade)
        {
            Hospedes = hospedes;
        }
        else
        {
            throw new Exception("A capacidade da suíte é insuficiente para o número de hóspedes.");
        }
    }

    public void CadastrarSuite(Suite suite)
    {
        Suite = suite;
    }

    public int ObterQuantidadeHospedes()
    {
        return Hospedes.Count;
    }

    public decimal CalcularValorDiaria()
    {
        // Cálculo: DiasReservados X Suite.ValorDiaria
        decimal valor = DiasReservados * Suite.ValorDiaria;

        // Aplica um desconto de 10% se os dias reservados forem maior ou igual a 10
        if (DiasReservados >= 10)
        {
            valor -= valor * 0.10m; // Aplicando o desconto de 10%
        }

        return valor;
    }
}