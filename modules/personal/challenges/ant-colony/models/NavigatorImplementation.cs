// namespace Sandbox.Challenges.AntColony;
// internal sealed class NavigatorImplementation : Navigator {

//     #region Fields

//     private Dictionary<int, double> _landmarkPheromoneLevels = new Dictionary<int, double>();

//     #endregion

//     #region Protected Methods

//     protected override List<Landmark> GeneratePath(List<Landmark> landmarks) {
//         List<Landmark> result = new ();
//         foreach (var landmark in landmarks) {
            
//         }
//         return null;
//     }

//     #endregion

//     #region Private Methods

//     private void VisitLandmark(Landmark landmark) {
//         double score = landmark.Value;
//         Ant ant = new ();
//         landmark.Visit(ant);
//         if (ant.Alive)
//             score = -score;
//     }

//     #endregion

// }