﻿/*
    Copyright (C) 2014-2016 de4dot@gmail.com

    This file is part of dnSpy

    dnSpy is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    dnSpy is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with dnSpy.  If not, see <http://www.gnu.org/licenses/>.
*/

using System.Collections.Generic;
using System.Linq;
using dnSpy.Contracts.Languages;
using dnSpy.Languages.ILSpy.Core.Properties;
using dnSpy.Languages.Settings;

namespace dnSpy.Languages.ILSpy.Settings {
	sealed class ILLanguageDecompilerSettings : DecompilerSettingsBase {
		public ILSettings Settings => ilSettings;
		readonly ILSettings ilSettings;

		public ILLanguageDecompilerSettings(ILSettings ilSettings = null) {
			this.ilSettings = ilSettings ?? new ILSettings();
			this.options = CreateOptions().ToArray();
		}

		public override DecompilerSettingsBase Clone() => new ILLanguageDecompilerSettings(this.ilSettings.Clone());

		public override IEnumerable<IDecompilerOption> Options => options;
		readonly IDecompilerOption[] options;

		IEnumerable<IDecompilerOption> CreateOptions() {
			yield return new DecompilerOption<bool>(DecompilerOptionConstants.ShowILComments_GUID,
						() => ilSettings.ShowILComments, a => ilSettings.ShowILComments = a) {
				Description = dnSpy_Languages_ILSpy_Core.DecompilerSettings_ShowILComments,
				Name = DecompilerOptionConstants.ShowILComments_NAME,
			};
			yield return new DecompilerOption<bool>(DecompilerOptionConstants.ShowXmlDocumentation_GUID,
						() => ilSettings.ShowXmlDocumentation, a => ilSettings.ShowXmlDocumentation = a) {
				Description = dnSpy_Languages_ILSpy_Core.DecompilerSettings_ShowXMLDocComments,
				Name = DecompilerOptionConstants.ShowXmlDocumentation_NAME,
			};
			yield return new DecompilerOption<bool>(DecompilerOptionConstants.ShowTokenAndRvaComments_GUID,
						() => ilSettings.ShowTokenAndRvaComments, a => ilSettings.ShowTokenAndRvaComments = a) {
				Description = dnSpy_Languages_ILSpy_Core.DecompilerSettings_ShowTokensRvasOffsets,
				Name = DecompilerOptionConstants.ShowTokenAndRvaComments_NAME,
			};
			yield return new DecompilerOption<bool>(DecompilerOptionConstants.ShowILBytes_GUID,
						() => ilSettings.ShowILBytes, a => ilSettings.ShowILBytes = a) {
				Description = dnSpy_Languages_ILSpy_Core.DecompilerSettings_ShowILInstrBytes,
				Name = DecompilerOptionConstants.ShowILBytes_NAME,
			};
			yield return new DecompilerOption<bool>(DecompilerOptionConstants.SortMembers_GUID,
						() => ilSettings.SortMembers, a => ilSettings.SortMembers = a) {
				Description = dnSpy_Languages_ILSpy_Core.DecompilerSettings_SortMethods,
				Name = DecompilerOptionConstants.SortMembers_NAME,
			};
		}

		protected override bool EqualsCore(object obj) =>
			obj is ILLanguageDecompilerSettings && ilSettings.Equals(((ILLanguageDecompilerSettings)obj).ilSettings);
		protected override int GetHashCodeCore() => ilSettings.GetHashCode();
	}
}
