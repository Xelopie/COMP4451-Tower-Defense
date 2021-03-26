using System.Collections.Generic;
using TowerDefense.Towers;
using UnityEngine;

namespace TowerDefense.UI
{
	public class RadiusVisualizerController : MonoBehaviour
	{
		/// <summary>
		/// Prefab used to visualize effect radius of tower
		/// </summary>
		public GameObject radiusVisualizerPrefab;
        public GameObject boxVisualizerPrefab;

		public float radiusVisualizerHeight = 0.02f;
        public float boxVisualizerHeight = 3.0f;

		/// <summary>
		/// The local euler angles
		/// </summary>
		public Vector3 radiusLocalEuler;
        public Vector3 boxLocalEuler;

		readonly List<GameObject> m_RadiusVisualizers = new List<GameObject>();
        readonly List<GameObject> m_BoxVisualizers = new List<GameObject>();

		/// <summary>
		/// Sets up the radius visualizer for a tower or ghost tower
		/// </summary>
		/// <param name="tower">
		/// The tower to get the data from
		/// </param>
		/// <param name="ghost">Transform of ghost to parent the visualiser to.</param>
		public void SetupRadiusVisualizers(Tower tower, Transform ghost = null)
		{
			// Create necessary affector radius visualizations
			List<ITowerRadiusProvider> providers =
				tower.levels[tower.currentLevel].GetRadiusVisualizers();

			int length = providers.Count;
			for (int i = 0; i < length; i++)
			{
				if (m_RadiusVisualizers.Count < i + 1)
				{
					m_RadiusVisualizers.Add(Instantiate(radiusVisualizerPrefab));
				}

                if (m_BoxVisualizers.Count < i + 1)
                {
                    m_BoxVisualizers.Add(Instantiate(boxVisualizerPrefab));
                }

				ITowerRadiusProvider provider = providers[i];

                if (provider.targetter.attachedCollider is BoxCollider)
                {
                    GameObject boxVisualizer = m_BoxVisualizers[i];
                    boxVisualizer.SetActive(true);
                    boxVisualizer.transform.SetParent(ghost == null ? tower.transform : ghost);
                    boxVisualizer.transform.localPosition = new Vector3(0, radiusVisualizerHeight, 0);
                    boxVisualizer.transform.localScale = new Vector3(provider.effectRadius * 2.0f, boxVisualizerHeight, provider.effectRadius * 2.0f);
                    boxVisualizer.transform.localRotation = new Quaternion { eulerAngles = boxLocalEuler };

                    var visualizerRenderer = boxVisualizer.GetComponent<Renderer>();
                    if (visualizerRenderer != null)
                    {
                        visualizerRenderer.material.color = provider.effectColor;
                    }
                }
                else
                {
                    GameObject radiusVisualizer = m_RadiusVisualizers[i];
                    radiusVisualizer.SetActive(true);
                    radiusVisualizer.transform.SetParent(ghost == null ? tower.transform : ghost);
                    radiusVisualizer.transform.localPosition = new Vector3(0, radiusVisualizerHeight, 0);
                    radiusVisualizer.transform.localScale = new Vector3(provider.effectRadius * 2.0f, 0.001f, provider.effectRadius * 2.0f);
                    radiusVisualizer.transform.localRotation = new Quaternion { eulerAngles = radiusLocalEuler };

                    var visualizerRenderer = radiusVisualizer.GetComponent<Renderer>();
                    if (visualizerRenderer != null)
                    {
                        visualizerRenderer.material.color = provider.effectColor;
                    }
                }
			}
		}

		/// <summary>
		/// Hides the radius visualizers
		/// </summary>
		public void HideRadiusVisualizers()
		{
			foreach (GameObject radiusVisualizer in m_RadiusVisualizers)
			{
				radiusVisualizer.transform.parent = transform;
				radiusVisualizer.SetActive(false);
			}
            foreach (GameObject boxVisualizer in m_BoxVisualizers)
            {
                boxVisualizer.transform.parent = transform;
                boxVisualizer.SetActive(false);
            }
        }
	}
}