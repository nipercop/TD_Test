using TMPro;
using UnityEngine;

namespace Game.UI.Abilities
{
    public class AbilityButtonView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        private int _id;
        System.Action<int> _onClick;
        public int Id => _id;

        public void SetData(int id, string nameAbility, System.Action<int> onClick)
        {
            _id = id;   
            _text .text = nameAbility;
            _onClick = onClick;
        }

        public void OnClick()
        {
            _onClick?.Invoke(_id);
        }

    }
}
