namespace DBEgzaminas_StudentuInfoSistema.Database.Entities
{
    public class Lecture
    {
        public string Name { get; set; }
        public DateTime StartTime { get; set; }

        public ICollection<Departament> Departaments { get; set; }
    }
}
