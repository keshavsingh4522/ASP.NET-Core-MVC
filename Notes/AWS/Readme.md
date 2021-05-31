- to use cli create access key
- configure cli
```
aws configure

==>
after this enter secret key,secret id, region code which is your near, for output format just leave empty.
```
- list users
```
aws iam list-users
```
- Access Advisor
```
show which service is used by user or which not
```

[ec2 Instance types](https://aws.amazon.com/ec2/instance-types/)

- Connect on pc using ssh
```
- copy the public ipv4 address of instance
- on your machine enter below code
ssh -i Key_file_name ec2-user@Place_Public_IPV4_Address_Here
```
- create ebs volume if you wish your data does not delete when you terminate instance
- create snapshot of volume and trnasfer to other volume in any of region
```
 - create snapshot
 - go to snapshot and click on that and click on copy and select region where you want to copy
 second way
 - create volume of snapshot and select different region
```
- EC2 Image Builder
```
- Go to EC2 Image Builder
- Create Image Pipeline
   - give name of your instance
   - select build shedule(select manual)
   - create receipe if you have no receipe
```