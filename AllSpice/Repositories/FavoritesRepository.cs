namespace AllSpice.Repositories;

public class FavoritesRepository
{
    private readonly IDbConnection _db;
    public FavoritesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Favorite CreateFavorite(Favorite favoriteData)
    {
        string sql = @"
            INSTER INTO favorites
                (recipeId, accountId, createdAt, updatedAt)
            VALUES
                (@recipeId, @accountId, @createdAt, @updatedAt);
            SELECT LAST_INSERT_ID();";
        int lastInsertId = _db.ExecuteScalar<int>(sql, favoriteData);
        favoriteData.Id = lastInsertId;
        return favoriteData;
    }


}