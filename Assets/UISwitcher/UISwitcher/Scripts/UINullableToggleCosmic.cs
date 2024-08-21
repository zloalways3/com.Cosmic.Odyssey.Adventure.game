using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
namespace UISwitcherCosmic {

	[Serializable]
	public class ValueChangedEventCosmic : UnityEvent<bool> {
	}

	
	public class UINullableToggleCosmic : Selectable, IPointerClickHandler {
		public event Action<bool> OnValueChanged;

		public ValueChangedEventCosmic onValueChanged = new ValueChangedEventCosmic();

		[SerializeField] private int m_isOnNullable;
		[SerializeField] private bool m_nullValueEnabled;

		public bool isOn {
			get {
				if (m_isOnNullable < 0) return false;
				return m_isOnNullable != 0;
			}
			set => Set1(value);
		}

		public void SetWithoutNotify1(bool? value) =>
				Set1(value, false);

		private void Set1(bool? value, bool notify = true) {
			if (m_isOnNullable == NullableBoolToInt1(value))
				return;

			if (!value.HasValue)
				m_isOnNullable = -1;
			else
				m_isOnNullable = value.Value ? 1 : 0;

			if (notify)
				ValueChangedNotify1(value);

			OnChanged1(value);
		}

		public virtual void OnChanged1( /*(int value*/) =>
				OnChanged1(IntToNullableBool1(m_isOnNullable));

		virtual protected void OnChanged1(bool? value) {}

		private void ValueChangedNotify1(bool? value) {
			if (value.HasValue) {
				OnValueChanged?.Invoke(value.Value);
				onValueChanged?.Invoke(value.Value);
			}

		}

		public void OnPointerClick(PointerEventData eventData) {
			if (m_nullValueEnabled)
				MoveToNextValue1();
			else
				MoveToBetweenTrueFalse1();
		}

		private void MoveToBetweenTrueFalse1() {
			if (!IsActive() || !IsInteractable())
				return;
			isOn = isOn switch {
					true => false,
					_ => true
			};
		}

		private void MoveToNextValue1() {
			if (!IsActive() || !IsInteractable())
				return;

			isOn = isOn switch {
					true => false,
					_ => true
			};
		}

		private int NullableBoolToInt1(bool? value) {
			if (!value.HasValue)
				return -1;
			return value.Value ? 1 : 0;
		}

		private bool? IntToNullableBool1(int value) {
			if (value > 0) return true;
			if (value == 0) return false;
			return null;
		}
	}
}