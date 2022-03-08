using System;
using Components;
using Leopotam.Ecs;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Systems
{
    public class  CreateTakenViewSystem : IEcsRunSystem
    {
        private EcsFilter<Taken, CellViewRef>.Exclude<TakenViewRef> _filter;
        private Configuration _configuration;
        public void Run()
        {
            foreach (var index in _filter)
            {
                var position = _filter.Get2(index).View.transform.position;
                var takenType = _filter.Get1(index).value;

                SignView sigView = null;

                switch (takenType)
                {
                    case SignType.None:
                        break;
                    case SignType.Cross:
                        sigView = _configuration.CrossView;
                        break;
                    case SignType.Ring:
                        sigView = _configuration.RingView;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
                var instance = Object.Instantiate(sigView, position, Quaternion.identity);
                _filter.GetEntity(index).Get<TakenViewRef>().View = instance;

            }
        }
    }
}