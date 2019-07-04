# Rey.Mapping
灵活的dotnet core映射库，主要为了解决AutoMapper在使用过程中不够灵活的问题。

# 使用
## 基本
``` C#
public class PersonFrom {
    public string Name { get; set; }
    public PersonFrom Parent { get; set; }
    public List<PersonFrom> Children { get; set; }
}

public class PersonTo {
    public string Name { get; set; }
    public PersonTo Parent { get; set; }
    public PersonTo[] Children { get; set; }
}

static void Main(string[] args) {
  var mapper = new MapperBuilder().Build();
  var from = new PersonFrom() {
      Name = "Person",
      Parent = new PersonFrom { Name = "Parent" },
      Children = new List<PersonFrom> {
          new PersonFrom{ Name = "Child 1" },
          new PersonFrom{ Name = "Child 2" }
      },
  };

  var to = mapper.From(from).To<PersonTo>();
}
```
## 忽略字段
### 从源对象上忽略字段
``` C#
var to = this.Mapper.From(from, opts => opts.Ignore(x => x.Name)).To<PersonTo>();
```
### 从目标对象上忽略字段
``` C#
var to = this.Mapper.From(from).To<PersonTo>(opts => opts.Ignore(x => x.Name));
```
## 字段映射
### 从源对象上映射
``` C#
var to = this.Mapper.From(from, opts => opts.Map(x => x.Name, "Parent.Name")).To<PersonTo>();
```
### 从目标对象上映射
``` C#
var to = this.Mapper.From(from).To<PersonTo>(opts => opts.Map(x => x.Name, x => x.Parent.Name));
```
