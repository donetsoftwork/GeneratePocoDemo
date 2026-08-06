using Hand.Models;
using System;

namespace CommentModel‌s;

/// <summary>
/// 评论
/// </summary>
/// <param name="id"></param>
/// <param name="createTime"></param>
public class Comment(CommentId id, CommentCreateTime createTime)
{
    /// <summary>
    /// 评论标识
    /// </summary>
    public CommentId Id { get; } = id;
    /// <summary>
    /// 评论内容
    /// </summary>
    public CommentContent Content { get; set; }
    /// <summary>
    /// 评论创建时间
    /// </summary>
    public CommentCreateTime CreateTime { get; } = createTime;

    /// <summary>
    /// 评论更新时间
    /// </summary>
    public CommentUpdateTime UpdateTime { get; set; }
}

/// <summary>
/// 评论标识
/// </summary>
/// <param name="Original"></param>
public readonly record struct CommentId(long Original) : IEntityId;
/// <summary>
/// 评论内容
/// </summary>
/// <param name="Original"></param>
public readonly record struct CommentContent(string Original) : IEntityProperty<string>;
/// <summary>
/// 评论创建时间
/// </summary>
/// <param name="Original"></param>
public readonly record struct CommentCreateTime(DateTime Original) : IEntityProperty<DateTime>;
/// <summary>
/// 评论更新时间
/// </summary>
/// <param name="Original"></param>
public readonly record struct CommentUpdateTime(DateTime Original) : IEntityProperty<DateTime>;