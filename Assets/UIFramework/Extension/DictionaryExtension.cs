using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 对dictionary的扩展
/// </summary>
public static class DictionaryExtension {
    /// <summary>
    /// 从key得到value
    /// </summary>
	public static Tvalue TryGet<Tkey, Tvalue>(this Dictionary<Tkey, Tvalue> dic, Tkey key)
    {
        Tvalue value;
        dic.TryGetValue(key, out value);
        return value;
    }
}
