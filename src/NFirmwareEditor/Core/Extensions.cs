﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JetBrains.Annotations;

namespace NFirmwareEditor.Core
{
	internal static class Extensions
	{
		internal static List<int> ToList([NotNull] this ListBox.SelectedIndexCollection indexCollection)
		{
			if (indexCollection == null) throw new ArgumentNullException("indexCollection");
			return new List<int>(indexCollection.Cast<int>());
		}

		internal static void AddRange([NotNull] this ListBox.SelectedIndexCollection indexCollection, [NotNull] IEnumerable<int> indices)
		{
			if (indexCollection == null) throw new ArgumentNullException("indexCollection");
			if (indices == null) throw new ArgumentNullException("indices");

			foreach (var index in indices)
			{
				indexCollection.Add(index);
			}
		}

		internal static void ForEach<T>([NotNull] this IEnumerable<T> collection, [NotNull] Action<T> action)
		{
			if (collection == null) throw new ArgumentNullException("collection");
			if (action == null) throw new ArgumentNullException("action");

			foreach (var item in collection)
			{
				action(item);
			}
		}

		internal static void Fill([NotNull] this ListBox listBox, [NotNull] IEnumerable<object> items, bool selectFirstItem)
		{
			if (listBox == null) throw new ArgumentNullException("listBox");
			if (items == null) throw new ArgumentNullException("items");

			listBox.Items.Clear();
			listBox.BeginUpdate();
			foreach (var item in items)
			{
				listBox.Items.Add(item);
			}
			listBox.EndUpdate();

			if (selectFirstItem && listBox.Items.Count > 0)
			{
				listBox.SelectedIndex = 0;
			}
		}

		internal static StringBuilder AppendLine([NotNull] this StringBuilder sb, [NotNull] string format, params object[] args)
		{
			if (sb == null) throw new ArgumentNullException("sb");
			if (string.IsNullOrEmpty(format)) throw new ArgumentNullException("format");

			sb.AppendLine(string.Format(format, args));
			return sb;
		}
	}
}