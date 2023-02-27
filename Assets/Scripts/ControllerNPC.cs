using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControllerNPC : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _animator;
    private Transform[] _pathPoints;
    private int _index = 0;
    private float _minDistance = 10;

    [SerializeField] GameObject path;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();

        _pathPoints = new Transform[path.transform.childCount];
        for(int i = 0; i < _pathPoints.Length; i++)
        {
            _pathPoints[i] = path.transform.GetChild(i);
        }
    }

    private void Update()
    {
        Walk();
    }

    void Walk()
    {
        if(Vector3.Distance(transform.position, _pathPoints[_index].position) < _minDistance)
        {
            if (_index + 1 != _pathPoints.Length)
            {
                _index++;
            }
            else
            {
                _index = 0;
            }
        }
        _animator.SetFloat("vertical", !_agent.isStopped ? 1 : 0); //������ �� Blend Tree. ��������� ���� ���� �� ����������� (!_agent.isStopped), ����� (?) �������� ����� 1, � �������� ������ = 0
        //������ ������� � Blend Tree, ��� ���������, ��� ��� 1 ����� ������������� �������� ������, � ��� 0 - �������� idle
        //_animator.SetFloat("horizontal", 1);
        _agent.SetDestination(_pathPoints[_index].position);
    }
}
