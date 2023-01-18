# Hello spring!
This week's challenge is focused on artificial intelligence and since spring is right around the corner, let's draw inspiration the behavior of ants!

Ants utilize pheromones to help coordinate the efforts of their colony. It's a very interesting concept, and it has a colorful array of practical applications. For example, ants utilize it to mark trails between their nest and a source of food, downed comrades, and much, much more. In this week's challenge, you'll utilize this concept to make decisions in your code!

The overall problem is rather simple; implement the `Navigator` object (shell created as `NavigatorImplementation`) and utilize the `GeneratePath(List<Landmark>)` method to determine the safest 
path through the landmarks resulting in the highest score. The only requirement is to ensure that the concept of pheromones is applied in your logic.

<sub>*For clarity, the safest path is the one which results in the least amount of ant deaths.*</sub>

### Test Code
```cs
Random random = new ();
List<Landmark> landmarks = new ();
for (int i = 0; i < 10; i++)
    landmarks.Add(new Landmark(i, random.NextDouble() * 250));

Navigator navigator = new NavigatorImplementation();
List<Landmark> optimalPath = navigator.FindOptimalPath();
```

### Navigator Implementation Shell
```cs
internal sealed class NavigatorImplementation : Navigator {
    protected override List<Landmark> GeneratePath(List<Landmark> landmarks) {
        // TODO: Generate a path 😁
        return null;
    }
}
```