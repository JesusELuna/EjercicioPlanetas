using System;

namespace Domain
{
    public class Planet
    {
        public Planet(string name,
                      Double angularVelocity,
                      Double distanceToStar,
                      Coordinate initialCoordinates)
        {
            this.Name = name;
            this.AngularVelocity = angularVelocity;
            this.DistanceToStar = distanceToStar;
            this.InitialCoordinates = initialCoordinates;
            this.GetCurrentPosition = initialCoordinates;
        }

        public double AngularVelocity { get; private set; }
        public double DistanceToStar { get; private set; }
        public string Name { get; private set; }
        public Coordinate InitialCoordinates { get; private set; }

        private double AngularVelocityRadians 
        {
            get { return ((AngularVelocity) * Math.PI) / 180; }
        }

        private double InitialPositionRadians
        {
            //https://gist.github.com/joeyklee/e9f328e4c0c13a19eb1800caa97df9fb
            get { return Math.Atan2(InitialCoordinates.Y - 0, InitialCoordinates.X - 0); }
        }


        public int DaysTotalTranslation()
        {
            return Convert.ToInt32(360 / AngularVelocity);
        }

        public double Movement(int dias) 
        {
            //Segun libro de física q(t) = q0 + w(t - t0)
            return InitialPositionRadians + (AngularVelocityRadians * dias);
        }

        public Coordinate GetCurrentPosition { get; private set; }

        public Coordinate GetPosition(int days)
        {
            //(x = 0 + rcosθ, y = 0 + rsinθ) = (x = rcosθ, y = rsinθ)
            double position = Movement(days);
            double X = DistanceToStar * Math.Cos(position);
            double Y = this.DistanceToStar * Math.Sin(position);
            return new Coordinate(X, Y);
        }

        public void Move(int day)
        {
            GetCurrentPosition = GetPosition(day);
        }
    }
}
