//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentExtensionsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Entitas;

public class IGeneratorCountListenerComponent : IComponent {
    public IGeneratorCountListener value;
}

namespace Entitas {
    public partial class Entity {
        public IGeneratorCountListenerComponent iGeneratorCountListener { get { return (IGeneratorCountListenerComponent)GetComponent(UIComponentIds.IGeneratorCountListener); } }

        public bool hasIGeneratorCountListener { get { return HasComponent(UIComponentIds.IGeneratorCountListener); } }

        public Entity AddIGeneratorCountListener(IGeneratorCountListener newValue) {
            var component = CreateComponent<IGeneratorCountListenerComponent>(UIComponentIds.IGeneratorCountListener);
            component.value = newValue;
            return AddComponent(UIComponentIds.IGeneratorCountListener, component);
        }

        public Entity ReplaceIGeneratorCountListener(IGeneratorCountListener newValue) {
            var component = CreateComponent<IGeneratorCountListenerComponent>(UIComponentIds.IGeneratorCountListener);
            component.value = newValue;
            ReplaceComponent(UIComponentIds.IGeneratorCountListener, component);
            return this;
        }

        public Entity RemoveIGeneratorCountListener() {
            return RemoveComponent(UIComponentIds.IGeneratorCountListener);
        }
    }
}

    public partial class UIMatcher {
        static IMatcher _matcherIGeneratorCountListener;

        public static IMatcher IGeneratorCountListener {
            get {
                if (_matcherIGeneratorCountListener == null) {
                    var matcher = (Matcher)Matcher.AllOf(UIComponentIds.IGeneratorCountListener);
                    matcher.componentNames = UIComponentIds.componentNames;
                    _matcherIGeneratorCountListener = matcher;
                }

                return _matcherIGeneratorCountListener;
            }
        }
    }