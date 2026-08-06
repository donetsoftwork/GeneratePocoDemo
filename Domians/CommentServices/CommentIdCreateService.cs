using CommentModels;
using Hand.Creational;

namespace CommentServices;

/// <summary>
/// 评论标识创建服务
/// </summary>
/// <param name="seed"></param>
public class CommentIdCreateService(int seed = 0)
    : ICreator<CommentId>
{
    private int _seed = seed;

    /// <inheritdoc />
    public CommentId Create()
    {
        // 这个可以用雪花算法代替
        var original = Interlocked.Increment(ref _seed);
        return new CommentId(original);
    }
}
