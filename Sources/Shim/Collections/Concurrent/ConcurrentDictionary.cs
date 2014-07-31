﻿/*
 *  Copyright (c) 2013-2014, Cureos AB.
 *  All rights reserved.
 *  http://www.cureos.com
 *
 *	This file is part of CSShim.
 *
 *  CSShim is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  CSShim is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with CSShim.  If not, see <http://www.gnu.org/licenses/>.
 */

using System.Collections.Generic;

namespace System.Collections.Concurrent
{
	public sealed class ConcurrentDictionary<TKey, TValue> : Dictionary<TKey, TValue>
	{
        #region METHODS

        public TValue AddOrUpdate(TKey key, Func<TKey, TValue> addValueFactory,
            Func<TKey, TValue, TValue> updateValueFactory)
        {
            TValue value;
            if (ContainsKey(key))
            {
                value = updateValueFactory(key, this[key]);
                this[key] = value;
            }
            else
            {
                value = addValueFactory(key);
                Add(key, value);
            }
            return value;
        }
        
        #endregion
	}
}