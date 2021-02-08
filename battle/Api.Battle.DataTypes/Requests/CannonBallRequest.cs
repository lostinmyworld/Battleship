namespace Api.Battle.DataTypes.Requests
{
    public class CannonBallRequest
    {
        public int PlayerId { get; set; }
        public Coordinate There { get; set; }
    }
}
