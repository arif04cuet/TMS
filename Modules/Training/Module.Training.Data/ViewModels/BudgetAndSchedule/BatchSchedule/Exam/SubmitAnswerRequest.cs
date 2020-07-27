namespace Module.Training.Data
{
    public class SubmitAnswerRequest
    {
        public long Question { get; set; }
        public long? McqAnswer { get; set; }
        public string WrittenAnswer { get; set; }
    }
}
