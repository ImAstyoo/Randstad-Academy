namespace Lesson4.@class;

public class AulaVirtuale{
  private static AulaVirtuale Aula{ get; }
  public static List<Alunno> Registro = new List<Alunno>();

  static AulaVirtuale(){
    Aula ??= new AulaVirtuale();
  }


  public class NotConnectedException : Exception{
    public NotConnectedException(string? message) : base(message){
    }
  }

  public static void IngressoAlunno(String nome){
    Registro.Add(new Alunno(nome));
  }

  static void UscitaAlunno(Alunno alunno, List<string?> registro){
    if (registro == null) throw new Exception(nameof(registro));
    registro.Remove(alunno.Nome);
  }
}