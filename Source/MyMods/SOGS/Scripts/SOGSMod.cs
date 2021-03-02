using Stationeers.Addons;
using Stationeers.Addons.API;
using UnityEngine;

namespace SOGS.Scripts
{
    public class SOGS : IPlugin
    {
        public void OnLoad()
        {
            Debug.Log("They say great science is built on the shoulders of giants. Not here. At Aperture, we do all our science from scratch. No hand holding.");

            //var monkey = BundleManager.GetAssetBundle("monkey").LoadAsset<Mesh>("monkey");
            //var basicModel = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //var basicModelTransform = basicModel.transform;
            //basicModel.GetComponent<MeshFilter>().sharedMesh = monkey;
            //basicModelTransform.position = Vector3.zero;
            //basicModelTransform.localScale = Vector3.one * 4.0f;
            //basicModelTransform.rotation = Quaternion.Euler(-90.0f, 0.0f, 0.0f);
        }

        public void OnUnload()
        {
            Debug.Log("Example Mod: Bye!");
        }
    }
}
