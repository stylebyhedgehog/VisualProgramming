
public class RatingCalculator 
{
    public static int calculateRating(int attempts, bool requireBlockUsed)
    {
        int rating = 0;
        if (attempts <= 3)
        {
            rating += 4;
        } else if(attempts > 3 && attempts <=6){
            rating += 3;
        } else if (attempts > 6)
        {
            rating += 2;
        }
        if (requireBlockUsed)
        {
            rating += 1;
        }
        return rating;
    }
}
