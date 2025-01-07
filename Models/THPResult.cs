﻿namespace THPCore.Models;

public class THPResult
{
    private static readonly THPResult _success = new() { Succeeded = true };
    private string _message = string.Empty;
    private object? _data;
    /// <summary>
    /// Flag indicating whether if the operation succeeded or not.
    /// </summary>
    /// <value>True if the operation succeeded, otherwise false.</value>
    public bool Succeeded { get; protected set; }
    public string Message => _message;
    public object? Data => _data;

    /// <summary>
    /// Returns an <see cref="THPResult"/> indicating a successful identity operation.
    /// </summary>
    /// <returns>An <see cref="THPResult"/> indicating a successful operation.</returns>
    public static THPResult Success => _success;

    /// <summary>
    /// Creates an <see cref="THPResult"/> indicating a failed identity operation, with a list of <paramref name="message"/> if applicable.
    /// </summary>
    /// <param name="message">An optional array of <see cref="Message"/>s which caused the operation to fail.</param>
    /// <returns>An <see cref="THPResult"/> indicating a failed identity operation, with a list of <paramref name="message"/> if applicable.</returns>
    public static THPResult Failed(string message)
    {
        var result = new THPResult { Succeeded = false };
        if (!string.IsNullOrEmpty(message))
        {
            result._message = message;
        }
        return result;
    }

    public static THPResult Ok(object? data) => new() { _data = data, Succeeded = true };
}

public class THPResult<T>
{
    private static readonly THPResult<T> _success = new() { Succeeded = true };
    private string _message = string.Empty;
    private T? _data;
    /// <summary>
    /// Flag indicating whether if the operation succeeded or not.
    /// </summary>
    /// <value>True if the operation succeeded, otherwise false.</value>
    public bool Succeeded { get; protected set; }
    public string Message => _message;
    public T? Data => _data;

    /// <summary>
    /// Returns an <see cref="THPResult"/> indicating a successful identity operation.
    /// </summary>
    /// <returns>An <see cref="THPResult"/> indicating a successful operation.</returns>
    public static THPResult<T> Success => _success;

    /// <summary>
    /// Creates an <see cref="THPResult"/> indicating a failed identity operation, with a list of <paramref name="message"/> if applicable.
    /// </summary>
    /// <param name="message">An optional array of <see cref="Message"/>s which caused the operation to fail.</param>
    /// <returns>An <see cref="THPResult"/> indicating a failed identity operation, with a list of <paramref name="message"/> if applicable.</returns>
    public static THPResult<T> Failed(string message)
    {
        var result = new THPResult<T> { Succeeded = false };
        if (!string.IsNullOrEmpty(message))
        {
            result._message = message;
        }
        return result;
    }

    public static THPResult<T> Ok(T? data) => new() { _data = data, Succeeded = true };
}
