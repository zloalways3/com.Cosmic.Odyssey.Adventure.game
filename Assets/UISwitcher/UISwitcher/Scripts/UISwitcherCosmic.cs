using UnityEngine;
using UnityEngine.UI;

namespace UISwitcherCosmic {
	public class UISwitcherCosmic : UINullableToggleCosmic {
		private readonly Vector2 _min1 = new Vector2(0, 0.5f);
		private readonly Vector2 _max1 = new Vector2(1, 0.5f);
		private readonly Vector2 _middle1 = new Vector2(0.5f, 0.5f);

		[SerializeField] private Graphic backgroundGraphic;
		[SerializeField] private Color onColor1, offColor1, nullColor1;
		[SerializeField] private RectTransform tipRect;
		private Color backgroundColor {
			set {
				if (backgroundGraphic == null) return;
				backgroundGraphic.color = value;
			}
		}
		protected override void OnChanged1(bool? obj) {
			if (obj.HasValue) {
				if (obj.Value)
					SetOn1();
				else
					SetOff1();
			}
			else {
				SetNull1();
			}
		}

		private void SetOn1() {
			SetAnchors1(_max1);
			backgroundColor = onColor1;
		}

		private void SetOff1() {
			SetAnchors1(_min1);
			backgroundColor = offColor1;
		}

		private void SetNull1() {
			SetAnchors1(_middle1);
			backgroundColor = nullColor1;
		}

		private void SetAnchors1(Vector2 anchor) {
			tipRect.anchorMin = anchor;
			tipRect.anchorMax = anchor;
			tipRect.pivot = anchor;
		}
	}
}