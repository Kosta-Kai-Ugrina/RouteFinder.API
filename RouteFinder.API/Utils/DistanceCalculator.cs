using static System.Math;

namespace RouteFinder.API.Utils
{
    public static class DistanceCalculator
    {
        public static double CalculateManhattanDistance(
            AddressRequest a,
            AddressRequest b)
        {
            var latADegrees = ConvertDegreesToRadians((double)a.Latitude!);
            var lngADegrees = ConvertDegreesToRadians((double)a.Longitude!);
            var latBDegrees = ConvertDegreesToRadians((double)b.Latitude!);
            var lngBDegrees = ConvertDegreesToRadians((double)b.Longitude!);

            var latDiff = Abs(latBDegrees - latADegrees);
            var latDist = latDiff * APPROX_METERS_PER_DEGREE_LAT;
            var latAvg = (latADegrees + latBDegrees) / 2;

            var metresPerDegreesLng = Cos(latAvg) * APPROX_METERS_PER_DEGREE_LAT;
            var lngDiff = Abs(lngBDegrees - lngADegrees);
            var lngDist = lngDiff * metresPerDegreesLng;

            var manhattanDistance = latDist + lngDist;

            return manhattanDistance;
        }

        private static double ConvertDegreesToRadians(double degrees)
            => degrees * (PI / 180.0);

        private const double APPROX_METERS_PER_DEGREE_LAT = 111000;

    }
}
