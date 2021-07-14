### VPC (Virtual Private Cloud)
```text
Amazon VPC enables you to build a virtual network in the AWS cloud - no VPNs, hardware, or physical datacenters required. You can define your own network space, and control how your network and the Amazon EC2 resources inside your network are exposed to the Internet
```
### VPC and Subnet Primer
- **VPC**
    - Private Network to deploy your resource(regional resource)
- **Subnet**
    - allow you to partion your network inside VPC(availability zone resource)
        - public subnet
            - it is accessable from the internet
        - private subnet
            - it is not accesable from the internet
- **Internet Gateway**
    - it helps our VPC instance to connect with the Internet
    - ***Public Subnet*** have route to the Internet Gateway
- **NAT Gateway**
```
NAT gateway(AWS Managed) & NAT Instances(Self Managed) allow your Instances in Private Subnets
to access the Internet while remaining Private
```

<details>
    <summary>Expand to see PIC</summary>
    <img src="Images/VPC/153 - VPC.png" />
    <img src="Images/VPC/154 - VPC diagram.png">
    <img src="Images/VPC/155 - Internet Gateway and Nat Gateway.png">
</details>
<br>

### Network ACL and Security  group
- **Network ACL** (Network Access Control List)
    - ***firewall*** which controls from and to subnet
    - can have ***Allow*** and ***Deny*** rules
    - are attached at the ***subnet level***
    - Rules only include IP Addresses
- **Security group**
    - A firewall that controls traffic to and from an ***ENI*** / an ***EC2*** Instances
    - can have only ***Allow*** rules
    - Rules include IP Addresses and other security group

[Difference b/w NACL and Security Group](https://www.javatpoint.com/aws-nacl-vs-security-group)

<details>
<summary>Diagram to clear the doubt</summary>
    <img src="Images/VPC/156 - NACL and Security Group.png">
</details>

### VPC flow logs
```
VPC Flow Logs is a feature that enables you to capture information about the IP traffic going to and from network interfaces in your VPC.

Flow log data can be published to Amazon CloudWatch Logs and Amazon S3. 

After you've created a flow log, you can retrieve and view its data in the chosen destination.
```

### VPC Peering
- connect two VPCs, privetly using AWS' Network
- Make them behave as if they were in the same network
- Must not have overlapping CIDR(ip address range)
- VPC connection is not transitive(must be established for each VPC that need to communicate with one another)

### VPC Endpoints
- Endpoints allows you to connect to AWS Service using a Private Network instaed of public Network.
- this gives you enhanced security and lower latency to access AWS Services.
- VPC Endpoint Gateway: connect only S3 and DynamoDB services privately
- VPC Endpoint Interface: connect rest services privately

### Site to Site VPN & Direct Connect
- Site to site VPN
```
connect an onpremise VPN server to AWS
the connection is automatically encrypted
goes over the public network
```
- Direct Connect
```
Establish a physical connection on premise and AWS
the connection is private, secure and fast
goes over private network
Takes atleast a month to establish
```
