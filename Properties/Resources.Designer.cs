﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TV_Slideshow_Config_Editor.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TV_Slideshow_Config_Editor.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Defaults.
        /// </summary>
        internal static string ConfigDefaultsTag {
            get {
                return ResourceManager.GetString("ConfigDefaultsTag", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Notifications.
        /// </summary>
        internal static string ConfigNotificationsTag {
            get {
                return ResourceManager.GetString("ConfigNotificationsTag", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;description&quot;: &quot;TV Slideshow Config&quot;,
        ///  &quot;type&quot;: &quot;object&quot;,
        ///  &quot;properties&quot;: {
        ///    &quot;defaults&quot;: {
        ///      &quot;type&quot;: &quot;object&quot;,
        ///      &quot;properties&quot;: {
        ///        &quot;durations&quot;: {
        ///          &quot;type&quot;: &quot;object&quot;,
        ///          &quot;properties&quot;: {
        ///            &quot;site&quot;: {
        ///              &quot;type&quot;: &quot;integer&quot;
        ///            },
        ///            &quot;slide&quot;: {
        ///              &quot;type&quot;: &quot;integer&quot;
        ///            },
        ///            &quot;notification&quot;: {
        ///              &quot;type&quot;: &quot;integer&quot;
        ///            }
        ///          },
        ///          &quot;required&quot;: [
        ///            &quot;site&quot; [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string ConfigSchema {
            get {
                return ResourceManager.GetString("ConfigSchema", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Sites.
        /// </summary>
        internal static string ConfigSitesTag {
            get {
                return ResourceManager.GetString("ConfigSitesTag", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TimeDisplay.
        /// </summary>
        internal static string ConfigTimeDisplayTag {
            get {
                return ResourceManager.GetString("ConfigTimeDisplayTag", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///	&quot;defaults&quot;: {
        ///		&quot;durations&quot;: {
        ///			&quot;site&quot;: 50,
        ///			&quot;slide&quot;: 15,
        ///			&quot;notification&quot;: 60
        ///		}
        ///	},
        ///	&quot;showTime&quot;: {
        ///		&quot;duration&quot;: 2,
        ///		&quot;interval&quot;: 5
        ///	},
        ///	&quot;sites&quot;: [
        ///		{
        ///			&quot;url&quot;: &quot;/001SlideShow/html/index.html&quot;,
        ///			&quot;height&quot;: &quot;100%&quot;
        ///		}
        ///	]
        ///}.
        /// </summary>
        internal static string DefaultJSON {
            get {
                return ResourceManager.GetString("DefaultJSON", resourceCulture);
            }
        }
    }
}
